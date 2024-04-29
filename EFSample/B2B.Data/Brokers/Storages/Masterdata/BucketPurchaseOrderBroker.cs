using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketPurchaseOrderBroker : IBucketPurchaseOrderBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketPurchaseOrderBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketPurchaseOrder> AddBucketPurchaseOrderAsync(BucketPurchaseOrder BucketPurchaseOrder)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketPurchaseOrders.AddAsync(BucketPurchaseOrder);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<BucketPurchaseOrder> UpdateBucketPurchaseOrderAsync(BucketPurchaseOrder BucketPurchaseOrder)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.BucketPurchaseOrders.Update(BucketPurchaseOrder);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketPurchaseOrderAsync(BucketPurchaseOrder BucketPurchaseOrder)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketPurchaseOrders.Remove(BucketPurchaseOrder);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketPurchaseOrder> GetAllBucketPurchaseOrders()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.BucketPurchaseOrders;
        }
    }
}