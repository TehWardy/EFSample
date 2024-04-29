namespace B2B.Objects.Entities.Logging
{
    public class AuditItemLevel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<InvoiceAuditItem> InvoiceAuditItems { get; set; }

        public virtual ICollection<CreditAuditItem> CreditAuditItems { get; set; }

        public virtual ICollection<OfferAuditItem> OfferAuditItems { get; set; }

        public virtual ICollection<PurchaseOrderAuditItem> PurchaseOrderAuditItems { get; set; }

        public virtual ICollection<RemittanceAdviceAuditItem> RemittanceAdviceAuditItems { get; set; }
    }
}