using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Payments;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class RemittanceAdviceTypeBroker : IRemittanceAdviceTypeBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public RemittanceAdviceTypeBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public IQueryable<RemittanceAdviceType> GetAllRemittanceAdviceTypes()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.RemittanceAdviceTypes;
        }
    }
}