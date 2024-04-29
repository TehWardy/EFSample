using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Banking
{
    public class Payee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PaymentText { get; set; }

        public Guid? AddressId { get; set; }

        public Guid? BankAccountId { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public virtual Address Address { get; set; }

        public virtual BankAccount BankAccount { get; set; }

        public virtual ICollection<CompanyPayee> Companies { get; set; }

        public virtual ICollection<BucketPayee> Buckets { get; set; }
    }
}