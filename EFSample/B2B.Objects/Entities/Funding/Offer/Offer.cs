using B2B.Objects.Entities.Logging;
using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Payments;

namespace B2B.Objects.Entities.Funding.Offer;

public class Offer
{
    public Guid Id { get; set; }

    public string SourceSystemId { get; set; }

    public string CurrencyId { get; set; }

    public string DebtorState { get; set; }

    public string CreditorState { get; set; }

    public string Comment { get; set; }

    public string Number { get; set; }

    public string DebtorName { get; set; }

    public string CreditorName { get; set; }

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

    public DateTimeOffset LastUpdated { get; set; }

    public string FunderName { get; set; }

    public string FunderState { get; set; }

    public string FunderExternalState { get; set; }


    // acceptance rules
    public bool? DebtorAcceptanceRule { get; set; }

    public bool? CreditorAcceptanceRule { get; set; }

    public bool? FunderAcceptanceRule { get; set; }

    // dates
    /*
     * IssueDate - 3rd Party External creation date prior to sending to the CLX platform
     * ExpiryDate - Date offer expires and is no longer acceptable
     */
    public DateTimeOffset IssueDate { get; set; }

    public DateTimeOffset? ExpiryDate { get; set; }

    public DateTimeOffset EarliestRelatedTaxPoint { get; set; }

    // Amounts

    public decimal TransactionValue { get; set; }

    public decimal FundableValue { get; set; }

    public decimal Rate { get; set; }

    public decimal Cost { get; set; }

    // related items

    public virtual Masterdata.System SourceSystem { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual ICollection<OfferDataItem> Data { get; set; }

    public virtual ICollection<OfferAuditItem> AuditTrail { get; set; } = new List<OfferAuditItem>();

    public virtual ICollection<OfferLine> Lines { get; set; }

    public virtual ICollection<OfferReference> References { get; set; }

    public virtual ICollection<OfferCompany> Companies { get; set; }

    public virtual ICollection<BucketOffer> Buckets { get; set; }

    public virtual ICollection<RemittanceAdviceLine> RemittanceAdviceLines { get; set; }

    public bool IsFullyAccepted()
    {
        // eval who's accepted what
        bool
            DebtorAccepted = AuditTrail.Any(e => e.Message.Contains("Debtor") && e.Message.Contains("FundingAccepted")),
            CreditorAccepted = AuditTrail.Any(e => e.Message.Contains("Creditor") && e.Message.Contains("FundingAccepted")),
            FunderAccepted = AuditTrail.Any(e => e.Message.Contains("Funder") && e.Message.Contains("FundingAccepted"));

        // eval acceptance requirements
        bool
            DebtorRequired = DebtorAcceptanceRule ?? false,
            CreditorRequired = CreditorAcceptanceRule ?? false,
            FunderRequired = FunderAcceptanceRule ?? false;

        // If anyone had MustAccept, make sure they have accepted.
        return DebtorRequired == DebtorAccepted && CreditorRequired == CreditorAccepted && FunderRequired == FunderAccepted;
    }

    public bool IsAccepted() =>
        !IsRejected() && (CreditorState == "FundingAccepted" || FunderState == "FundingAccepted");

    public DateTimeOffset? AcceptedOn() =>
        AuditTrail.LastOrDefault(e => e.Message.Contains("FundingAccepted"))?.CreatedOn;

    public bool IsRejected() =>
        DebtorState == "RejectedCancelled" || CreditorState == "RejectedCancelled" || FunderState == "RejectedCancelled";

    public bool IsFullyCompleted()
    {
        // eval who's Completed what
        bool
           DebtorCompleted = AuditTrail.Any(e => e.Message.Contains("Debtor") && e.Message.Contains("Complete")),
           CreditorCompleted = AuditTrail.Any(e => e.Message.Contains("Creditor") && e.Message.Contains("Complete")),
           FunderCompleted = AuditTrail.Any(e => e.Message.Contains("Funder") && e.Message.Contains("Complete"));

        // eval completing requirements - for now let's presume it's the same as acceptance requirements
        bool
            DebtorRequired = DebtorAcceptanceRule ?? false,
            CreditorRequired = CreditorAcceptanceRule ?? false,
            FunderRequired = FunderAcceptanceRule ?? false;

        // If anyone had MustAccept, make sure they have Completed.
        return DebtorRequired == DebtorCompleted && CreditorRequired == CreditorCompleted && FunderRequired == FunderCompleted;
    }
}