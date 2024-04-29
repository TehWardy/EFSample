using B2B.Data.Brokers.Storages.Funding.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Funding.Offer;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Funding
{
    public class OfferCompanyBroker : IOfferCompanyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public OfferCompanyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<OfferCompany> AddOfferCompanyAsync(OfferCompany offerCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.OfferCompanies.AddAsync(offerCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteOfferCompanyAsync(OfferCompany offerCompany)
        {
            using var context = contextFactory.CreateDbContext();
            context.OfferCompanies.Remove(offerCompany);
            await context.SaveChangesAsync();
        }

        public IQueryable<OfferCompany> GetAllOfferCompanies(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.OfferCompanies.IgnoreQueryFilters()
                : readContext.OfferCompanies;
        }
    }
}