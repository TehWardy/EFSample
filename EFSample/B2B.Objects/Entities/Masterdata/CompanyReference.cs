using B2B.Objects.Entities.Funding.Offer;
using B2B.Objects.Entities.Payments;
using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Objects.Entities.Masterdata
{
    public class CompanyReference
    {
        public string Id { get; set; }

        public string Value { get; set; }

        public string SystemId { get; set; }

        public Guid CompanyId { get; set; }

        public virtual B2BSystem System { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<InvoiceCompany> InvoiceReferences { get; set; }

        public virtual ICollection<CreditCompany> CreditReferences { get; set; }

        public virtual ICollection<PurchaseOrderCompany> PurchaseOrderReferences { get; set; }

        public virtual ICollection<RemittanceAdviceCompany> RemittanceAdviceReferences { get; set; }

        public virtual ICollection<OfferCompany> OfferReferences { get; set; }
    }
}
