using B2B.Objects.Entities.Security;

namespace B2B.Objects.Entities.Masterdata;

public class BucketRole
{
    public Guid RoleId { get; set; }

    public Guid BucketId { get; set; }

    public virtual B2BRole Role { get; set; }

    public virtual Bucket Bucket { get; set; }
}