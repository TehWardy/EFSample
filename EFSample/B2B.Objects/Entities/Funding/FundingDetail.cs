using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Funding
{
    public class FundingDetail
    {
        public int Id { get; set; }

        public bool IsSystematic { get; set; }

        public decimal CurrentLimit { get; set; }

        public decimal Limit { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Formula { get; set; }

        public string BuyerReferenceId { get; set; }

        public string SupplierReferenceId { get; set; }

        public string FunderReferenceId { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTimeOffset LastUpdated { get; set; }

        public string SystemId { get; set; }

        public string CurrencyId { get; set; }

        public Guid FundingTypeBucketId { get; set; }

        public virtual Masterdata.System System { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual Bucket FundingTypeBucket { get; set; }
    }
}