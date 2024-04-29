namespace B2B.Objects.Dtos;

public class ReturnItem
{
    public Guid CLXId { get; set; }

    public string BuyerReference { get; set; }
    public string SupplierReference { get; set; }
    public string FunderReference { get; set; }

    public string BuyerDocumentReference { get; set; }
    public string SupplierDocumentreference { get; set; }

    public DateTimeOffset AcceptanceDate { get; set; }
    public DateTimeOffset? FunderPaymentDate { get; set; }
    public DateTimeOffset? BuyerPaymentDate { get; set; }

    public decimal DiscountApplied { get; set; }
    public decimal TransactionValue { get; set; }
    public decimal FundableValue { get; set; }
}