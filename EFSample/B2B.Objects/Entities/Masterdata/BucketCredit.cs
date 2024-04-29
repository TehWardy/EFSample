using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities.Masterdata;

public class BucketCredit
{
    public Guid CreditId { get; set; }

    public Guid BucketId { get; set; }

    public virtual Credit Credit { get; set; }

    public virtual Bucket Bucket { get; set; }
}