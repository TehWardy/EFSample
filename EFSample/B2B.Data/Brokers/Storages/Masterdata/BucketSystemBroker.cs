using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketSystemBroker : IBucketSystemBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketSystemBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketSystem> AddBucketSystemAsync(BucketSystem bucketSystem)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketSystems.AddAsync(bucketSystem);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketSystemAsync(BucketSystem bucketSystem)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketSystems.Remove(bucketSystem);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketSystem> GetAllBucketSystems()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.BucketSystems;
        }
    }
}