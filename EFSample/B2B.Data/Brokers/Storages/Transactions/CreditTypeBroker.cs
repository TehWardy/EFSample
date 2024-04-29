using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Transactions;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class CreditTypeBroker : ICreditTypeBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CreditTypeBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public IQueryable<CreditType> GetAllCreditTypes()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.CreditTypes;
        }
    }
}