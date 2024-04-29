using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketBroker : IBucketBroker
    {
        private readonly IB2BDbContextFactory contextFactory;

        public BucketBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<Bucket> AddBucketAsync(Bucket Bucket)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.Buckets.AddAsync(Bucket);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<Bucket> UpdateBucketAsync(Bucket Bucket)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.Buckets.Update(Bucket);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketAsync(Bucket Bucket)
        {
            using var context = contextFactory.CreateDbContext();
            context.Buckets.Remove(Bucket);
            await context.SaveChangesAsync();
        }

        public IQueryable<Bucket> GetAllBuckets(bool ignoreFilters = false)
        {
            var context = contextFactory.CreateDbContext();

            return ignoreFilters
                ? context.Buckets.IgnoreQueryFilters()
                : context.Buckets;
        }
    }
}