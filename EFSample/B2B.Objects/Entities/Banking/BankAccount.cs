using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Payments;

namespace B2B.Objects.Entities.Banking
{
    public class BankAccount
    {
        public Guid Id { get; set; }

        public Guid? BankBranchId { get; set; }

        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public virtual BankBranch BankBranch { get; set; }

        public virtual ICollection<Payee> Payees { get; set; }

        public virtual ICollection<RemittanceAdviceLine> DebtorPayments { get; set; }

        public virtual ICollection<RemittanceAdviceLine> CreditorPayments { get; set; }

        public virtual ICollection<BucketBankAccount> Buckets { get; set; }
    }
}