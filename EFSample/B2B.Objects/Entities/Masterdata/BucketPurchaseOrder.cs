using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities.Masterdata
{
    public class BucketPurchaseOrder
    {
        public Guid PurchaseOrderId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public Guid BucketId { get; set; }

        public virtual Bucket Bucket { get; set; }
    }
}