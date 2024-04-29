using B2B.Objects.Entities.Payments;

namespace B2B.Objects.Entities.Funding.Offer;

public class OfferReference
{
    public string Id { get; set; }

    public string Value { get; set; }

    public string SystemId { get; set; }

    public Guid OfferId { get; set; }

    public virtual Masterdata.System System { get; set; }

    public virtual Offer Offer { get; set; }

    public virtual ICollection<RemittanceAdviceLine> RemittanceAdviceLines { get; set; }
}