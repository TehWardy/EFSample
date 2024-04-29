namespace B2B.Objects.Entities.Masterdata
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactEmailAddress { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string WebsiteUrl { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public DateTimeOffset? DateTradingEnabled { get; set; }

        public bool IsActive { get; set; }

        public bool IsVerified { get; set; }

        public Guid? AddressId { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<CompanyReference> References { get; set; }

        public virtual ICollection<BucketCompany> Buckets { get; set; }

        public virtual ICollection<CompanyPayee> Payees { get; set; }
    }
}