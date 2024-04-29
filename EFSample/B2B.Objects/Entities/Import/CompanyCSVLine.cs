using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Import;

public class CompanyCSVLine
{
    public Guid Id { get; set; }

    public Guid RootBucketId { get; set; }

    public Guid? CompanyId { get; set; }

    public string Perspective { get; set; }

    public string Name { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string AddressZipOrPostalCode { get; set; }

    public string AddressTownOrCity { get; set; }

    public string AddressPoBox { get; set; }

    public string AddressRegion { get; set; }

    public string AddressCountryId { get; set; }

    public string Reference { get; set; }

    public string GlobalTax { get; set; }

    public string SourceSystemId { get; set; }

    public char ReferenceSeperator { get; set; }

    public string FileName { get; set; }

    public string ProcessingState { get; set; }

    public string FailureMessage { get; set; }

    public DateTimeOffset CreatedOn { get; set; }
    public string CreatedBy { get; set; }

    public DateTimeOffset ProcessedOn { get; set; }

    public virtual Bucket RootBucket { get; set; }
}
