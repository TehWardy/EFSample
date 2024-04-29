using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Security;

public class B2BRole
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string CreatedBy { get; set; }

    public string LastUpdatedBy { get; set; }

    public string Privs { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    public bool UsersArePortalAdmins { get; set; }

    public virtual ICollection<BucketRole> Buckets { get; set; }

    public virtual ICollection<B2BUserRole> Users { get; set; }
}