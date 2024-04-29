using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing.Interfaces
{
    public interface IPurchaseOrderAuditItemBroker
    {
        ValueTask<PurchaseOrderAuditItem> AddPurchaseOrderAuditItemAsync(PurchaseOrderAuditItem purchaseOrderAuditItem);
        ValueTask DeletePurchaseOrderAuditItemAsync(PurchaseOrderAuditItem purchaseOrderAuditItem);
        IQueryable<PurchaseOrderAuditItem> GetAllPurchaseOrderAuditItems();
    }
}