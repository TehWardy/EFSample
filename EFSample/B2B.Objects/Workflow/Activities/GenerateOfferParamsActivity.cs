using B2B.Objects.Dtos;
using B2B.Objects.DTOs;
using B2B.Objects.Entities.Funding;
using B2B.Objects.Entities.Transactions;
using cCoder.Core.Objects.Dtos;
using cCoder.Core.Objects.Dtos.Workflow;
using cCoder.Core.Objects.Entities.Planning;
using cCoder.Core.Objects.Extensions;
using Newtonsoft.Json;

namespace B2B.Objects.Workflow.Activities;

public class GenerateOfferParamsActivity : B2BActivity<GenerateOfferParams>
{
    [JsonIgnore]
    [IgnoreWhenFlowComplete]
    public IEnumerable<ActiveTransaction> Items { get; set; }

    public int? CalendarId { get; set; }
    public string CutoffEventName { get; set; }
    public string PaymentEventName { get; set; }

    [JsonIgnore]
    [IgnoreWhenFlowComplete]
    public IEnumerable<GenerateOfferParams> Results { get; set; }

    public string ComputeCode { get; set; }

    public string SourceSystemId { get; set; }
    public DateTime Expiry { get; set; } = DateTime.Today;
    public string ExpiryTime { get; set; } = "23:59";

    public override async Task Execute()
    {
        if (Items == null || !Items.Any())
        {
            Log(WorkflowLogLevel.Warning, "No items provided, skipping generation.");
            Results = [];
        }
        else
        {
            DateTimeOffset funderPaymentDate = await GetFunderPaymentDate();
            Results = await BuildGenerationParams(Items, funderPaymentDate);
        }
    }

    public async Task<IEnumerable<GenerateOfferParams>> BuildGenerationParams(
        IEnumerable<ActiveTransaction> transactions,
        DateTimeOffset funderPaymentDate)
    {
        var expires = Expiry.AsUTCOffset().Add(TimeSpan.Parse(ExpiryTime));

        Log(WorkflowLogLevel.Info, $"Offers Generated will expire on {expires:yyyy-MM-dd} at {expires:hh:mm}");

        if (expires > DateTimeOffset.UtcNow)
        {
            return (await ComputerOfferLineValues(transactions, funderPaymentDate))
                .Select(i => BuildParamsItem(i, expires, funderPaymentDate))
                .ToArray();
        }
        else
        {
            Log(WorkflowLogLevel.Info, $"As the expiry time is in the past, skipping generation.");
            return [];
        }
    }

    public async ValueTask<IEnumerable<(ActiveTransaction Transaction, decimal OfferLineValue)>> ComputerOfferLineValues(
        IEnumerable<ActiveTransaction> transactions,
        DateTimeOffset funderPaymentDate)
    {
        var rates = await GetCurrentRates();

        var computeList = transactions
            .Select(t => $" new OfferValue {{ Reference = \"{t.Id}\",  Value = {ComputeFormula(t, funderPaymentDate, rates)} }}");

        var computes = string.Join(",\n", computeList);
        string script = "Func<IEnumerable<OfferValue>> f = () => { return new OfferValue[] {" + computes + "}; }; return f;";

        try
        {
            ComputeCode = script;
            var values = (await BuildScript<Func<IEnumerable<OfferValue>>>(script))();
            return transactions.Select(i => (i, values.First(v => v.Reference == i.Id).Value));
        }
        catch (Exception ex)
        {
            Log(WorkflowLogLevel.Error, $"Error in script... \n{script}");
            Log(WorkflowLogLevel.Error, $"{ex.Message} - {ex.StackTrace}");
            throw;
        }
    }

    public static FundingDetail FundingDetailFor(ActiveTransaction transaction)
    {
        var details = transaction.Buckets
            .Select(b => b.Bucket)
            .SelectMany(s => s.FundingDetails);

        // look for exact match
        var result = details
            .FirstOrDefault(d => d.CurrencyId == transaction.CurrencyId && d.BuyerReferenceId == transaction.DebtorReference);

        // look for a currency only match
        result ??= details
            .FirstOrDefault(d => d.CurrencyId == transaction.CurrencyId && d.BuyerReferenceId == null);

        return result;
    }

    public async Task<Rate[]> GetCurrentRates()
    {
        using HttpClient api = GetHttpClient();
        return (await api.GetAsync<ODataCollection<Rate>>("B2B/Rate/Current()")).Value.ToArray();
    }

    public async ValueTask<DateTimeOffset> GetFunderPaymentDate()
    {
        DateTimeOffset funderPaymentDate = GetPaymentDay(GetNextCutoff(DateTimeOffset.Now));

        if (CalendarId != null)
        {
            using HttpClient api = GetHttpClient();
            CalendarEvent cutoffEvent = (await api.GetAsync<ODataCollection<CalendarEvent>>($"Core/CalendarEvent?$filter=CalendarId eq {CalendarId} and Name eq '{CutoffEventName}' and Start ge {DateTimeOffset.Now:yyyy-MM-dd}&$top=1&$orderby=Start asc&$select=Start")).Value.FirstOrDefault();

            if (cutoffEvent != null)
            {
                CalendarEvent paymentEvent = (await api.GetAsync<ODataCollection<CalendarEvent>>($"Core/CalendarEvent?$filter=CalendarId eq {CalendarId} and Name eq '{PaymentEventName}' and Start ge {cutoffEvent.Start:yyyy-MM-dd}&$top=1&$orderby=Start asc&$select=Start")).Value.FirstOrDefault();

                if (paymentEvent != null)
                    funderPaymentDate = paymentEvent.Start;
            }
        }

        Log(WorkflowLogLevel.Info, $"Funder Payment Date is: {funderPaymentDate:yyyy-MM-dd}");
        return funderPaymentDate;
    }

    private GenerateOfferParams BuildParamsItem(
        (ActiveTransaction Transaction, decimal OfferLineValue) i,
        DateTimeOffset expires,
        DateTimeOffset funderPaymentDate) => new()
        {
            CurrencyId = i.Transaction.CurrencyId,
            Transactions = [$"{i.Transaction.TransactionType}|{i.Transaction.SourceSystemId}|{i.Transaction.TransactionReference}"],
            References = [BuildRef(i.Transaction)],
            SourceSystemId = i.Transaction.SourceSystemId,
            Value = i.OfferLineValue,
            Expires = expires,
            FunderPaymentDate = funderPaymentDate
        };

    private static string ComputeFormula(ActiveTransaction transaction, DateTimeOffset funderPaymentDate, Rate[] rates)
    {
        var fundingDetail = FundingDetailFor(transaction);

        if (fundingDetail == null)
            return "0.0m";

        Dictionary<string, string> dict = new()
        {
            { "fundablevalue", $"{transaction.FundableValue}m" },
            { "facevalue", $"{transaction.Value}m" },
            { "days", $"{Math.Ceiling((transaction.DebtorPaymentDate - funderPaymentDate).TotalDays)}" }
        };

        if (rates is not null && rates.Length != 0)
            foreach (var rate in rates)
                dict.Add(rate.Name.ToLower(), rate.Value.ToString() + "m");

        var result = fundingDetail.Formula.ToLowerInvariant();
        dict.ForEach(d => result = result.Replace(d.Key, d.Value));
        return result.ToLower();
    }

    private static DateTimeOffset GetPaymentDay(DateTimeOffset from) =>
        GetNextWorkingDay(from.AddDays(1));

    private static DateTimeOffset GetNextCutoff(DateTimeOffset from)
    {
        var dates = new List<DateTimeOffset>() {
            new(from.Year, from.Month, 10, 0, 0, 0, TimeSpan.Zero),
            new(from.Year, from.Month, 20, 0, 0, 0, TimeSpan.Zero),
            new(from.Year, from.Month, DateTime.DaysInMonth(from.Year, from.Month), 0, 0, 0, TimeSpan.Zero),
            (new DateTimeOffset(from.Year, from.Month, 10, 0, 0, 0, TimeSpan.Zero)).AddMonths(1)
        };

        return GetNextWorkingDay(dates.First(d => d >= from));
    }

    private static DateTimeOffset GetNextWorkingDay(DateTimeOffset date)
    {
        DateTimeOffset workingDay = date;
        while (workingDay.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
            workingDay = workingDay.AddDays(1);

        return workingDay;
    }

    private string BuildRef(ActiveTransaction t) =>
        $"{SourceSystemId}|{t.RelatedTransactionReference?.Split('|')?.Last() ?? t.TransactionReference}_{DateTimeOffset.Now:yyyyMMdd}";
}