using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketRemittanceAdviceBroker : IBucketRemittanceAdviceBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketRemittanceAdviceBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketRemittanceAdvice> AddBucketRemittanceAdviceAsync(BucketRemittanceAdvice BucketRemittanceAdvice)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketRemittanceAdvices.AddAsync(BucketRemittanceAdvice);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<BucketRemittanceAdvice> UpdateBucketRemittanceAdviceAsync(BucketRemittanceAdvice BucketRemittanceAdvice)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.BucketRemittanceAdvices.Update(BucketRemittanceAdvice);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketRemittanceAdviceAsync(BucketRemittanceAdvice BucketRemittanceAdvice)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.BucketRemittanceAdvices.Remove(BucketRemittanceAdvice);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketRemittanceAdvice> GetAllBucketRemittanceAdvices(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.BucketRemittanceAdvices.IgnoreQueryFilters()
                : readContext.BucketRemittanceAdvices;
        }
    }
}
