using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class CountryBroker : ICountryBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CountryBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public IQueryable<Country> GetAllCountries()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.Countries;
        }
    }
}