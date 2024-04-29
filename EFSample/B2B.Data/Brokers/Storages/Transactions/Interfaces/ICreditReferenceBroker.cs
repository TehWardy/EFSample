using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface ICreditReferenceBroker
    {
        ValueTask<CreditReference> AddCreditReferenceAsync(CreditReference creditReference);
        ValueTask DeleteCreditReferenceAsync(CreditReference creditReference);
        IQueryable<CreditReference> GetAllCreditReferences(bool ignoreFilters = false);
        ValueTask<CreditReference> UpdateCreditReferenceAsync(CreditReference creditReference);
    }
}