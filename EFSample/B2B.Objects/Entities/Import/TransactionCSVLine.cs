using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Import;

public class TransactionCSVLine
{
    public Guid Id { get; set; }

    public Guid RootBucketId { get; set; }

    public Guid? TransactionId { get; set; }

    public string TransactionType { get; set; }

    public string SourceSystemId { get; set; }

    public char ReferenceSeperator { get; set; }

    public string FileName { get; set; }

    public string State { get; set; }

    public string FailureMessage { get; set; }

    public string CreatedBy { get; set; }

    public string Reference { get; set; }

    public string CreditorTransactionRef { get; set; }

    public string DebtorRef { get; set; }

    public string CreditorRef { get; set; }

    public string VATRef { get; set; }

    public string Currency { get; set; }

    public string DocDate { get; set; }

    public string DueDate { get; set; }

    public string PaymentDate { get; set; }

    public string RelatedTransactionRef { get; set; }

    public string PayRef { get; set; }

    public string Description { get; set; }

    public decimal Value { get; set; }

    public decimal GrossValue { get; set; }

    public decimal TaxValue { get; set; }

    public bool IsFundable { get; set; }

    public bool IsRaLine { get; set; }

    public bool AlsoPayOffer { get; set; }

    public string ProcessingState { get; set; }

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset ProcessedOn { get; set; }

    public virtual Bucket RootBucket { get; set; }
}