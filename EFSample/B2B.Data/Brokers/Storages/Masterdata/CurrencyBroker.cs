using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class CurrencyBroker : ICurrencyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CurrencyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public IQueryable<Currency> GetAllCurrencies()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.Currencies;
        }
    }
}