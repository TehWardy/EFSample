using B2B.Objects.Entities.Banking;

namespace B2B.Objects.Entities.Masterdata
{
    public class BucketBankAccount
    {
        public Guid BankAccountId { get; set; }

        public Guid BucketId { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Bucket Bucket { get; set; }
    }
}