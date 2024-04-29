using B2B.Objects.Entities.Transactions;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IPurchaseOrderBroker
    {
        ValueTask<PurchaseOrder> AddPurchaseOrderAsync(PurchaseOrder purchaseOrder);
        ValueTask DeletePurchaseOrderAsync(PurchaseOrder purchaseOrder);
        IQueryable<PurchaseOrder> GetAllPurchaseOrders();
        ValueTask<PurchaseOrder> UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder);
    }
}