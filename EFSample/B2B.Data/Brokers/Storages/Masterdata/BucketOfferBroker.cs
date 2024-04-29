using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketOfferBroker : IBucketOfferBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketOfferBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketOffer> AddBucketOfferAsync(BucketOffer BucketOffer)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketOffers.AddAsync(BucketOffer);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<BucketOffer> UpdateBucketOfferAsync(BucketOffer BucketOffer)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.BucketOffers.Update(BucketOffer);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketOfferAsync(BucketOffer BucketOffer)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketOffers.Remove(BucketOffer);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketOffer> GetAllBucketOffers(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();
            return ignoreFilters
                ? readContext.BucketOffers.IgnoreQueryFilters()
                : readContext.BucketOffers;
        }
    }
}