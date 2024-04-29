using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Banking
{
    public class Bank
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? AddressId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<BankBranch> Branches { get; set; }
    }
}