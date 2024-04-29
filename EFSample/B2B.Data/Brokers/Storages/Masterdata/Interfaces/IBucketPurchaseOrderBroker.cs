using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketPurchaseOrderBroker
    {
        ValueTask<BucketPurchaseOrder> AddBucketPurchaseOrderAsync(BucketPurchaseOrder userRole);
        ValueTask<BucketPurchaseOrder> UpdateBucketPurchaseOrderAsync(BucketPurchaseOrder userRole);
        ValueTask DeleteBucketPurchaseOrderAsync(BucketPurchaseOrder userRole);
        IQueryable<BucketPurchaseOrder> GetAllBucketPurchaseOrders();
    }
}
