using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities.Masterdata
{
    public class BucketInvoice
    {
        public Guid InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }

        public Guid BucketId { get; set; }

        public virtual Bucket Bucket { get; set; }
    }
}