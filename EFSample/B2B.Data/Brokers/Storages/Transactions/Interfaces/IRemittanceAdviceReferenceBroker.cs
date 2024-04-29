using B2B.Objects.Entities.Payments;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IRemittanceAdviceReferenceBroker
    {
        ValueTask<RemittanceAdviceReference> AddRemittanceAdviceReferenceAsync(RemittanceAdviceReference remittanceAdviceReference);
        ValueTask DeleteRemittanceAdviceReferenceAsync(RemittanceAdviceReference remittanceAdviceReference);
        IQueryable<RemittanceAdviceReference> GetAllRemittanceAdviceReferences(bool ignoreFilters = false);
        ValueTask<RemittanceAdviceReference> UpdateRemittanceAdviceReferenceAsync(RemittanceAdviceReference remittanceAdviceReference);
    }
}