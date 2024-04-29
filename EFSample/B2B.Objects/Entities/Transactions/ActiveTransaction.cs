using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Transactions;

public class ActiveTransaction
{
    public string Id { get; set; }

    // name of source <T>
    public string TransactionType { get; set; }
    // PK in source <T> table
    public Guid TransactionId { get; set; }

    // PK to <TType>TypeId
    public int TypeId { get; set; }

    public string FunderReference { get; set; }

    public string TransactionReference { get; set; }

    public string DebtorName { get; set; }

    public string DebtorReference { get; set; }

    public string DebtorVATReference { get; set; }

    public string DebtorExternalState { get; set; }

    public string DebtorState { get; set; }

    public string CreditorName { get; set; }

    public string CreditorReference { get; set; }

    public string CreditorVATReference { get; set; }

    public string CreditorExternalState { get; set; }

    public string CreditorState { get; set; }

    public string FundingState { get; set; }

    public string FunderExternalState { get; set; }

    public string RelatedTransactionReference { get; set; }

    public string Comment { get; set; }

    public string Number { get; set; }

    public decimal OfferValue { get; set; }

    public decimal OfferRate { get; set; }

    public decimal CostOfFunding { get; set; }

    public decimal Value { get; set; }

    public decimal ValueBeforeTax { get; set; }

    public decimal ValueOfTax { get; set; }

    public decimal FundableValue { get; set; }

    public decimal UnpaidValue { get; set; }

    public DateTimeOffset? OfferExpiryDate { get; set; }

    public DateTimeOffset? DebtorGeneralLedgerDate { get; set; }

    public DateTimeOffset? CreditorGeneralLedgerDate { get; set; }

    public DateTimeOffset TaxPoint { get; set; }

    public DateTimeOffset? AgreedDiscountPaymentDate { get; set; }

    public DateTimeOffset? ProposedDiscountPaymentDate { get; set; }

    public DateTimeOffset? OfferAcceptanceDate { get; set; }

    public DateTimeOffset? CreationDate { get; set; }

    public DateTimeOffset? DeliveryDate { get; set; }

    public DateTimeOffset? ReceivedDate { get; set; }

    public DateTimeOffset? CaptureDate { get; set; }

    public DateTimeOffset DueDate { get; set; }

    public DateTimeOffset DebtorPaymentDate { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    public string SourceSystemId { get; set; }

    public string CurrencyId { get; set; }

    public virtual Masterdata.System SourceSystem { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual ICollection<BucketActiveTransaction> Buckets { get; set; }
}