using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketInvoiceBroker : IBucketInvoiceBroker
    {
        private readonly IB2BDbContextFactory contextFactory;

        public BucketInvoiceBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketInvoice> AddBucketInvoiceAsync(BucketInvoice bucketInvoice)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketInvoices.AddAsync(bucketInvoice);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<BucketInvoice> UpdateBucketInvoiceAsync(BucketInvoice bucketInvoice)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.BucketInvoices.Update(bucketInvoice);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketInvoiceAsync(BucketInvoice bucketInvoice)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketInvoices.Remove(bucketInvoice);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketInvoice> GetAllBucketInvoices(bool ignoreFilters = false)
        {
            var context = contextFactory.CreateDbContext();

            return ignoreFilters
                ? context.BucketInvoices.IgnoreQueryFilters()
                : context.BucketInvoices;
        }
    }
}
