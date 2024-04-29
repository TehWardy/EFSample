using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities
{
    public class PurchaseOrderCompany
    {
        public string Id { get; set; }

        public string Perspective { get; set; }

        public string CompanyReferenceId { get; set; }

        public virtual CompanyReference CompanyReference { get; set; }

        public Guid PurchaseOrderId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}