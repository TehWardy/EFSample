using B2B.Objects.Entities.Payments;

namespace B2B.Objects.Entities.Masterdata;

public class BucketRemittanceAdvice
{
    public Guid RemittanceAdviceId { get; set; }

    public Guid BucketId { get; set; }

    public virtual RemittanceAdvice RemittanceAdvice { get; set; }

    public virtual Bucket Bucket { get; set; }
}