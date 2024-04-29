using B2B.Objects.Entities.Funding;
using B2B.Objects.Entities.Funding.Offer;
using B2B.Objects.Entities.Payments;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities.Masterdata
{
    public class Currency
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RemittanceAdvice> RemittenceAdvices { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<FundingDetail> FundingDetails { get; set; }

        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<CreditLine> CreditLines { get; set; }
        public virtual ICollection<OfferLine> OfferLines { get; set; }
        public virtual ICollection<RemittanceAdviceLine> RemittanceAdviceLines { get; set; }
        public virtual ICollection<ActiveTransaction> ActiveTransactions { get; set; }
    }
}