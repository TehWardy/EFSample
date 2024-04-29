using B2B.Objects.Entities.Funding;
using B2B.Objects.Entities.Funding.Offer;
using B2B.Objects.Entities.Payments;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities.Masterdata
{
    public class System
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public bool IsPublic { get; set; }

        public virtual ICollection<BucketSystem> Buckets { get; set; }

        public virtual ICollection<CompanyReference> CompanyReferences { get; set; }

        public virtual ICollection<InvoiceReference> InvoiceReferences { get; set; }

        public virtual ICollection<CreditReference> CreditReferences { get; set; }

        public virtual ICollection<OfferReference> OfferReferences { get; set; }

        public virtual ICollection<PurchaseOrderReference> PurchaseOrderReferences { get; set; }

        public virtual ICollection<RemittanceAdviceReference> RemittanceAdviceReferences { get; set; }

        public virtual ICollection<FundingDetail> FundingDetails { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        public virtual ICollection<RemittanceAdvice> RemittanceAdvices { get; set; }

        public virtual ICollection<ActiveTransaction> ActiveTransactions { get; set; }
    }
}