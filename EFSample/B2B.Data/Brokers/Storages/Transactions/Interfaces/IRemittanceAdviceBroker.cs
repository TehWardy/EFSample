using B2B.Objects.Entities.Payments;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces;

public interface IRemittanceAdviceBroker
{
    ValueTask<RemittanceAdvice> AddRemittanceAdviceAsync(RemittanceAdvice remittanceAdvice);
    ValueTask DeleteRemittanceAdviceAsync(RemittanceAdvice remittanceAdvice);
    IQueryable<RemittanceAdvice> GetAllRemittanceAdvices();
    ValueTask<RemittanceAdvice> UpdateRemittanceAdviceAsync(RemittanceAdvice remittanceAdvice);
    ValueTask DeleteAllRemittanceAdviceForSystem(string sourceSystemId);

    IEnumerable<Guid> ComputeBuckets(string[] invoiceRefs, string[] creditRefs);
    IEnumerable<(string companyReferenceId, string perspective)> GetCompanies(string[] invoiceRefs, string[] creditRefs);
}