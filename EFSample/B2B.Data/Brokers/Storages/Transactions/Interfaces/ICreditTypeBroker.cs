using B2B.Objects.Entities.Transactions;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface ICreditTypeBroker
    {
        IQueryable<CreditType> GetAllCreditTypes();
    }
}