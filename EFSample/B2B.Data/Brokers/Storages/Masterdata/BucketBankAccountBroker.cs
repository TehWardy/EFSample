using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketBankAccountBroker : IBucketBankAccountBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketBankAccountBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketBankAccount> AddBucketBankAccountAsync(BucketBankAccount BucketBankAccount)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketBankAccounts.AddAsync(BucketBankAccount);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketBankAccountAsync(BucketBankAccount BucketBankAccount)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketBankAccounts.Remove(BucketBankAccount);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketBankAccount> GetAllBucketBankAccounts()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.BucketBankAccounts;
        }
    }
}
