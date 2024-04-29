using B2B.Data.Brokers.Storages.Auditing.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing
{
    public class PurchaseOrderAuditItemBroker : IPurchaseOrderAuditItemBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public PurchaseOrderAuditItemBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<PurchaseOrderAuditItem> AddPurchaseOrderAuditItemAsync(PurchaseOrderAuditItem purchaseOrderAuditItem)
        {
            using var context = contextFactory.CreateDbContext();

            var entityEntry = await context.PurchaseOrderAuditItems.AddAsync(purchaseOrderAuditItem);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeletePurchaseOrderAuditItemAsync(PurchaseOrderAuditItem purchaseOrderAuditItem)
        {
            using var context = contextFactory.CreateDbContext();

            context.PurchaseOrderAuditItems.Remove(purchaseOrderAuditItem);
            await context.SaveChangesAsync();
        }

        public IQueryable<PurchaseOrderAuditItem> GetAllPurchaseOrderAuditItems()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.PurchaseOrderAuditItems;
        }
    }
}