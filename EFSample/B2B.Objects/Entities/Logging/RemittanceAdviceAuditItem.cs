using B2B.Objects.Entities.Payments;
using B2B.Objects.Entities.Security;

namespace B2B.Objects.Entities.Logging;

public class RemittanceAdviceAuditItem
{
    public Guid Id { get; set; }

    public string Source { get; set; }

    public string Reference { get; set; }

    public string Message { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string UserId { get; set; }

    public int AuditItemLevelId { get; set; }

    public Guid RemittanceAdviceId { get; set; }

    public virtual B2BUser User { get; set; }

    public virtual AuditItemLevel AuditItemLevel { get; set; }

    public virtual RemittanceAdvice RemittanceAdvice { get; set; }
}