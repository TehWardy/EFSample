using B2B.Objects.Entities.Funding.Offer;

namespace B2B.Objects.Entities.Masterdata;

public class BucketOffer
{
    public Guid OfferId { get; set; }

    public Guid BucketId { get; set; }

    public virtual Offer Offer { get; set; }

    public virtual Bucket Bucket { get; set; }
}