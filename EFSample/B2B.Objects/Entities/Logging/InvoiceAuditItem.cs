using B2B.Objects.Entities.Security;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities.Logging;

public class InvoiceAuditItem
{
    public Guid Id { get; set; }

    public string Source { get; set; }

    public string Reference { get; set; }

    public string Message { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public string UserId { get; set; }

    public int AuditItemLevelId { get; set; }

    public Guid InvoiceId { get; set; }

    public virtual B2BUser User { get; set; }

    public virtual AuditItemLevel AuditItemLevel { get; set; }

    public virtual Invoice Invoice { get; set; }
}