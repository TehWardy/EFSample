using B2B.Objects.Entities.Logging;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Transactions;

public class Credit
{
    public Guid Id { get; set; }

    public string DebtorName { get; set; }

    public string DebtorState { get; set; }

    public string DebtorExternalState { get; set; }

    public string CreditorName { get; set; }

    public string CreditorState { get; set; }

    public string CreditorExternalState { get; set; }

    public string FunderName { get; set; }

    public string FundingState { get; set; }

    public string FunderExternalState { get; set; }

    public string Comment { get; set; }

    public string Number { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; }

    public string LastUpdatedBy { get; set; }

    public decimal Value { get; set; }

    public decimal ValueBeforeTax { get; set; }

    public decimal ValueOfTax { get; set; }

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

    public DateTimeOffset LastUpdated { get; set; }

    public DateTimeOffset? DebtorGeneralLedgerDate { get; set; }

    public DateTimeOffset? CreditorGeneralLedgerDate { get; set; }

    public DateTimeOffset TaxPoint { get; set; }

    public DateTimeOffset? AgreedDiscountPaymentDate { get; set; }

    public string CurrencyId { get; set; }

    public string SourceSystemId { get; set; }

    public int CreditTypeId { get; set; }

    public string InvoiceReferenceId { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual Masterdata.System SourceSystem { get; set; }

    public virtual CreditType CreditType { get; set; }

    public virtual InvoiceReference InvoiceReference { get; set; }

    public virtual ICollection<CreditAuditItem> AuditTrail { get; set; } = new List<CreditAuditItem>();

    public virtual ICollection<CreditLine> Lines { get; set; }

    public virtual ICollection<CreditReference> References { get; set; }

    public virtual ICollection<CreditCompany> Companies { get; set; }

    public virtual ICollection<BucketCredit> Buckets { get; set; }
}