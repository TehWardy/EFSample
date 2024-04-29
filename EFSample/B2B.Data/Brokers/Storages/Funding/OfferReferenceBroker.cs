using B2B.Data.Brokers.Storages.Funding.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Funding.Offer;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Funding
{
    public class OfferReferenceBroker : IOfferReferenceBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public OfferReferenceBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<OfferReference> AddOfferReferenceAsync(OfferReference offerReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.OfferReferences.AddAsync(offerReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<OfferReference> UpdateOfferReferenceAsync(OfferReference offerReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.OfferReferences.Update(offerReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteOfferReferenceAsync(OfferReference offerReference)
        {
            using var context = contextFactory.CreateDbContext();
            context.OfferReferences.Remove(offerReference);
            await context.SaveChangesAsync();
        }

        public IQueryable<OfferReference> GetAllOfferReferences(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.OfferReferences.IgnoreQueryFilters()
                : readContext.OfferReferences;
        }
    }
}