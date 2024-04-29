using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities
{
    public class PurchaseOrderLine
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public bool IsActive { get; set; }

        public string ProductCode { get; set; }

        public int LineNumber { get; set; }

        public decimal LinePrice { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TaxFee { get; set; }

        public decimal TaxableAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public string CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        public Guid PurchaseOrderId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}