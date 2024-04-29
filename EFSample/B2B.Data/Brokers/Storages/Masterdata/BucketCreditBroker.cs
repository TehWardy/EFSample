using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketCreditBroker : IBucketCreditBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketCreditBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketCredit> AddBucketCreditAsync(BucketCredit BucketCredit)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketCredits.AddAsync(BucketCredit);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<BucketCredit> UpdateBucketCreditAsync(BucketCredit BucketCredit)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.BucketCredits.Update(BucketCredit);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketCreditAsync(BucketCredit BucketCredit)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketCredits.Remove(BucketCredit);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketCredit> GetAllBucketCredits(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.BucketCredits.IgnoreQueryFilters()
                : readContext.BucketCredits;
        }
    }
}
