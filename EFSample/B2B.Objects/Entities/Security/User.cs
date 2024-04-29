using B2B.Objects.Entities.Logging;
using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Payments;

namespace B2B.Objects.Entities.Security;

public class B2BUser
{
    public string Id { get; set; }

    public string DisplayName { get; set; }

    public string EmailAddress { get; set; }

    public string MobilePhone { get; set; }

    public string WorkPhone { get; set; }

    public bool IsActive { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    public string JobTitle { get; set; }

    public Guid? AddressId { get; set; }

    public virtual Address Address { get; set; }

    public virtual ICollection<RemittanceAdvice> RAHeads { get; set; }

    public virtual ICollection<B2BUserRole> Roles { get; set; }

    public virtual ICollection<BucketUser> Buckets { get; set; }

    public virtual ICollection<CreditAuditItem> CreditAuditItems { get; set; }

    public virtual ICollection<InvoiceAuditItem> InvoiceAuditItems { get; set; }

    public virtual ICollection<OfferAuditItem> OfferAuditItems { get; set; }

    public virtual ICollection<PurchaseOrderAuditItem> PurchaseOrderAuditItems { get; set; }

    public virtual ICollection<RemittanceAdviceAuditItem> RemittanceAdviceAuditItems { get; set; }
}