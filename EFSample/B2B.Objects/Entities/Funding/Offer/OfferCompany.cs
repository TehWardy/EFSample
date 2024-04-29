using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Funding.Offer;

public class OfferCompany
{
    public string Id { get; set; }

    public string Perspective { get; set; }

    public string CompanyReferenceId { get; set; }

    public Guid OfferId { get; set; }

    public virtual CompanyReference CompanyReference { get; set; }

    public virtual Offer Offer { get; set; }
}