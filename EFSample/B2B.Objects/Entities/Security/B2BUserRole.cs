namespace B2B.Objects.Entities.Security;

public class B2BUserRole
{
    public Guid RoleId { get; set; }

    public string UserId { get; set; }

    public virtual B2BUser User { get; set; }

    public virtual B2BRole Role { get; set; }
}