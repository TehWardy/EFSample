using B2B.Objects.Entities.Funding;
using B2B.Objects.Entities.Import;

namespace B2B.Objects.Entities.Masterdata
{
    public class Bucket
    {
        public Guid Id { get; set; }

        public string Path { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public Guid? ParentId { get; set; }

        public virtual Bucket Parent { get; set; }

        public virtual ICollection<BucketSystem> Systems { get; set; }

        public virtual ICollection<BucketCompany> Companies { get; set; }

        public virtual ICollection<BucketRole> Roles { get; set; }

        public virtual ICollection<BucketBankAccount> BankAccounts { get; set; }

        public virtual ICollection<BucketPayee> Payees { get; set; }

        public virtual ICollection<BucketUser> Users { get; set; }

        public virtual ICollection<BucketInvoice> Invoices { get; set; }

        public virtual ICollection<BucketRemittanceAdvice> RemittanceAdvices { get; set; }

        public virtual ICollection<BucketOffer> Offers { get; set; }

        public virtual ICollection<BucketPurchaseOrder> PurchaseOrders { get; set; }

        public virtual ICollection<BucketCredit> Credits { get; set; }

        public virtual ICollection<BucketActiveTransaction> ActiveTransactions { get; set; }

        public virtual ICollection<Bucket> Buckets { get; set; }

        public virtual ICollection<FundingDetail> FundingDetails { get; set; }

        public virtual ICollection<CompanyCSVLine> CompanyCSVLines { get; set; }

        public virtual ICollection<TransactionCSVLine> TransactionCSVLines { get; set; }

    }
}