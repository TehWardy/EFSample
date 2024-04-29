using B2B.Objects.Entities.Funding.Offer;
using B2B.Objects.Entities.Payments;
using B2B.Objects.Entities.Transactions;
using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Objects.Entities;

public class InvoiceReference
{
    public string Id { get; set; }

    public string Value { get; set; }

    public string SystemId { get; set; }

    public Guid InvoiceId { get; set; }

    public virtual B2BSystem System { get; set; }

    public virtual Invoice Invoice { get; set; }

    public virtual ICollection<Credit> Credits { get; set; }

    public virtual ICollection<OfferLine> OfferLines { get; set; }

    public virtual ICollection<RemittanceAdviceLine> RemittanceAdviceLines { get; set; }

}