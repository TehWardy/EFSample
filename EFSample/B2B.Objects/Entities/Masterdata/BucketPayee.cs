using B2B.Objects.Entities.Banking;

namespace B2B.Objects.Entities.Masterdata
{
    public class BucketPayee
    {
        public Guid PayeeId { get; set; }

        public virtual Payee Payee { get; set; }

        public Guid BucketId { get; set; }

        public virtual Bucket Bucket { get; set; }
    }
}