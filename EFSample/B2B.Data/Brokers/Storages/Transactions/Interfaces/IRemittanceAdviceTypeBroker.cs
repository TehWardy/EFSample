using B2B.Objects.Entities.Payments;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IRemittanceAdviceTypeBroker
    {
        IQueryable<RemittanceAdviceType> GetAllRemittanceAdviceTypes();
    }
}