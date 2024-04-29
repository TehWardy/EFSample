using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities.Masterdata;

public class BucketActiveTransaction
{
    public string ActiveTransactionId { get; set; }

    public Guid BucketId { get; set; }

    public virtual ActiveTransaction ActiveTransaction { get; set; }

    public virtual Bucket Bucket { get; set; }
}