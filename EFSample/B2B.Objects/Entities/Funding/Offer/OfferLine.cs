using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Funding.Offer;

public class OfferLine
{
    public Guid Id { get; set; }

    public int LineNumber { get; set; }

    public string Description { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    public bool IsActive { get; set; }

    public string ProductCode { get; set; }

    public decimal LinePrice { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Quantity { get; set; }

    public decimal TaxRate { get; set; }

    public decimal TaxFee { get; set; }

    public decimal TaxableAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TransactionValue { get; set; }

    public decimal FundableValue { get; set; }

    public decimal Rate { get; set; }

    public decimal Cost { get; set; }

    public string CurrencyId { get; set; }

    public Guid OfferId { get; set; }

    public string InvoiceReferenceId { get; set; }

    public string CreditReferenceId { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual Offer Offer { get; set; }

    public virtual InvoiceReference InvoiceReference { get; set; }

    public virtual CreditReference CreditReference { get; set; }
}