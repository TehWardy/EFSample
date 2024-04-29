using B2B.Objects.DTOs;
using cCoder.Core.Objects.Dtos;
using cCoder.Core.Objects.Dtos.Workflow;
using cCoder.Core.Objects.Extensions;
using Newtonsoft.Json;

namespace B2B.Objects.Workflow.Activities;

public class GenerateOffersActivity : GenerateOfferParamsActivity
{
    [JsonIgnore]
    [IgnoreWhenFlowComplete]
    public IEnumerable<Result<GenerateOfferParams>> ApiResults { get; set; }

    public override async Task Execute()
    {
        await base.Execute();
        using HttpClient api = GetHttpClient();
        await SendDataToApi(api, Results);
    }

    private async Task SendDataToApi(HttpClient api, IEnumerable<GenerateOfferParams> offers)
    {
        Log(WorkflowLogLevel.Info, $"Generating {offers.Count()} offers of which {offers.Where(o => o.Value != 0).Count()} are valuable");
        List<Result<GenerateOfferParams>> results = [];

        foreach (IEnumerable<GenerateOfferParams> batch in GetBatches(offers.Where(o => o.Value != 0)))
        {
            Log(WorkflowLogLevel.Info, $"Batch of {batch.Count()} offers processing.");
            results.AddRange((await api.CallOdataAction<ODataCollection<Result<GenerateOfferParams>>>("B2B/Offer/GenerateAll", new ODataCollection<GenerateOfferParams> { Value = batch })).Value);
            Log(WorkflowLogLevel.Info, $"Batch of {batch.Count()} offers processed.");
        }

        ApiResults = results;
    }

    private IEnumerable<IEnumerable<GenerateOfferParams>> GetBatches(IEnumerable<GenerateOfferParams> data)
    {
        List<IGrouping<string, GenerateOfferParams>> referenceGroups = data
            .GroupBy(p => string.Join("|", p.References.OrderBy(r => r)))
            .ToList();

        List<GenerateOfferParams> batch = [];

        while (referenceGroups.Count != 0)
        {
            batch.AddRange(referenceGroups.First());
            referenceGroups.RemoveAt(0);

            if (batch.Count >= BatchSize || referenceGroups.Count == 0)
            {
                GenerateOfferParams[] returnResult = [.. batch];
                yield return returnResult;
                batch.Clear();
            }
        }
    }
}