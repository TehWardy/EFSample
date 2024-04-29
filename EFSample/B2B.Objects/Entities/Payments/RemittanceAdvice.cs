using B2B.Objects.Entities.Logging;
using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Security;

namespace B2B.Objects.Entities.Payments;

public class RemittanceAdvice
{
    public Guid Id { get; set; }

    public string DebtorState { get; set; }

    public string CreditorState { get; set; }

    public string FunderState { get; set; }

    public string Comment { get; set; }

    public string Number { get; set; }

    public string DebtorName { get; set; }

    public string CreditorName { get; set; }

    public string FunderName { get; set; }

    public string DebtorExternalState { get; set; }

    public string CreditorExternalState { get; set; }

    public decimal Value { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; }

    public string LastUpdatedBy { get; set; }

    /*
    CreationDate - Date Created in CLX (CLX back end will set this on creation)
    ReceivedDate - Date T details were received by Creditor
    DueDate - Date Debtor will pay Supplier (or Funder on offers)
    DebtorPaymentDate - Date Debtor Will actually pay
    CaptureDate - date manually entered in to system by an AP clerk
    DeliveryDate - date of goods or services being supplied for invoice to buyer from supplier
    */

    public DateTimeOffset? CreationDate { get; set; }

    public DateTimeOffset? ReceivedDate { get; set; }

    public DateTimeOffset DueDate { get; set; }

    public DateTimeOffset? DebtorPaymentDate { get; set; }

    public DateTimeOffset? CaptureDate { get; set; }

    public DateTimeOffset? DeliveryDate { get; set; }

    public DateTime Effective { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    public string SourceSystemId { get; set; }

    public string CurrencyId { get; set; }

    public int RemittanceAdviceTypeId { get; set; }

    //TODO: Remove this EF generated field...

    public string B2BUserId { get; set; }

    public virtual Masterdata.System SourceSystem { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual B2BUser B2BUser { get; set; }

    public virtual RemittanceAdviceType RemittanceAdviceType { get; set; }

    public virtual ICollection<RemittanceAdviceAuditItem> AuditTrail { get; set; } = new List<RemittanceAdviceAuditItem>();

    public virtual ICollection<RemittanceAdviceLine> Lines { get; set; }

    public virtual ICollection<RemittanceAdviceReference> References { get; set; }

    public virtual ICollection<RemittanceAdviceCompany> Companies { get; set; }

    public virtual ICollection<BucketRemittanceAdvice> Buckets { get; set; }
}