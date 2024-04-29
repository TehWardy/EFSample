using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Banking
{
    public class BankBranch
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid BankId { get; set; }

        public Guid? AddressId { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public virtual Address Address { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual ICollection<BankAccount> Accounts { get; set; }
    }
}