using B2B.Objects.Entities.Security;

namespace B2B.Objects.Entities.Masterdata
{
    public class BucketUser
    {
        public string UserId { get; set; }

        public virtual B2BUser User { get; set; }

        public Guid BucketId { get; set; }

        public virtual Bucket Bucket { get; set; }
    }
}