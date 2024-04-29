using B2B.Objects.Entities.Masterdata;
using cCoder.Core.Objects.Dtos;
using cCoder.Core.Objects.Dtos.Workflow;
using cCoder.Core.Objects.Extensions;

namespace B2B.Objects.Workflow.Activities
{
    public class CompanyImport : B2BActivity<Company>
    {
        public IEnumerable<Company> Companies { get; set; }
        public override async Task Execute()
        {
            Query = $"B2B/Company/AddOrUpdateAll?$expand=Item($expand=References,Address)";
            if (Companies != null && Companies.Any())
            {
                Log(WorkflowLogLevel.Info, $"HTTP POST {BaseUrl}{Query}");
                using System.Net.Http.HttpClient api = GetHttpClient();

                List<Result<Company>> res = new();
                Log(WorkflowLogLevel.Info, $"Sending {Companies.Count()} companies in batches of {BatchSize}");

                foreach (IEnumerable<Company> batch in Companies.BatchesOf(BatchSize))
                {
                    res.AddRange(await api.PostAllAsync(Query, batch));
                    Log(WorkflowLogLevel.Info, $"Batch of {batch.Count()} Companys processed.");
                }

                Result = res;
            }
            else
            {
                Log(WorkflowLogLevel.Warning, $"Nothing to process.");
                Result = Array.Empty<Result<Company>>();
            }
        }
    }
}
