using B2B.Objects.Entities.Banking;

namespace B2B.Objects.Entities.Masterdata
{
    public class CompanyPayee
    {
        public bool IsDefault { get; set; }

        public Guid PayeeId { get; set; }

        public virtual Payee Payee { get; set; }

        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}