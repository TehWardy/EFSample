using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketActiveTransactionBroker : IBucketActiveTransactionBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketActiveTransactionBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketActiveTransaction> AddBucketActiveTransactionAsync(BucketActiveTransaction bucketActiveTransaction)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketActiveTransactions.AddAsync(bucketActiveTransaction);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketActiveTransactionAsync(BucketActiveTransaction bucketActiveTransaction)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.BucketActiveTransactions.Remove(bucketActiveTransaction);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketActiveTransaction> GetAllBucketActiveTransactions(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.BucketActiveTransactions.IgnoreQueryFilters()
                : readContext.BucketActiveTransactions;
        }
    }
}