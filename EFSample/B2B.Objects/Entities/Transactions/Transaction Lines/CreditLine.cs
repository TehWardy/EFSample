using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities;

public class CreditLine
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

    public bool IsFundable { get; set; }

    public decimal TaxRate { get; set; }

    public decimal TaxFee { get; set; }

    public decimal TaxableAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public string CurrencyId { get; set; }

    public Guid CreditId { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual Credit Credit { get; set; }
}