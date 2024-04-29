namespace B2B.Objects.Entities.Masterdata
{
    public class BucketCompany
    {
        public Guid CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public Guid BucketId { get; set; }

        public virtual Bucket Bucket { get; set; }
    }
}