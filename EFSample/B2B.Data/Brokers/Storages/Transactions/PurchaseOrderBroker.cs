using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Transactions;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class PurchaseOrderBroker : IPurchaseOrderBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public PurchaseOrderBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<PurchaseOrder> AddPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.PurchaseOrders.AddAsync(purchaseOrder);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<PurchaseOrder> UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.PurchaseOrders.Update(purchaseOrder);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeletePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            using var context = contextFactory.CreateDbContext();
            context.PurchaseOrders.Remove(new PurchaseOrder() { Id = purchaseOrder.Id });
            await context.SaveChangesAsync();
        }

        public IQueryable<PurchaseOrder> GetAllPurchaseOrders()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.PurchaseOrders;
        }
    }
}