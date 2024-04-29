using B2B.Objects.Entities.Banking;
using B2B.Objects.Entities.Security;

namespace B2B.Objects.Entities.Masterdata
{
    public class Address
    {
        public Guid Id { get; set; }

        public string PoBox { get; set; }

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string ZipOrPostalCode { get; set; }

        public string TownOrCity { get; set; }

        public string StateOrProvince { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public string CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Bank> Banks { get; set; }

        public virtual ICollection<BankBranch> BankBranches { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<Payee> Payees { get; set; }

        public virtual ICollection<B2BUser> Users { get; set; }
    }
}