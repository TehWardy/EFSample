using B2B.Objects.Entities.Banking;
using B2B.Objects.Entities.Funding.Offer;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Payments;

public class RemittanceAdviceLine
{
    public Guid Id { get; set; }

    public int LineNumber { get; set; }

    public string Description { get; set; }

    public decimal LinePrice { get; set; }

    public DateTimeOffset LastUpdated { get; set; }

    public bool IsActive { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentReference { get; set; }

    public string CurrencyId { get; set; }

    //TODO: Retire direct link between RA Lines & Offers

    public Guid? OfferId { get; set; }

    //information about the money

    public Guid? DebtorAccountId { get; set; }

    public Guid? CreditorAccountId { get; set; }

    //parent doc

    public Guid RemittanceAdviceId { get; set; }

    //parent related collections

    public string InvoiceReferenceId { get; set; }

    public string CreditReferenceId { get; set; }

    public string PurchaseOrderReferenceId { get; set; }

    public string OfferReferenceId { get; set; }

    public virtual Currency Currency { get; set; }

    public virtual Offer Offer { get; set; }

    public virtual BankAccount DebtorAccount { get; set; }

    public virtual BankAccount CreditorAccount { get; set; }

    public virtual RemittanceAdvice RemittanceAdvice { get; set; }

    public virtual InvoiceReference InvoiceReference { get; set; }

    public virtual CreditReference CreditReference { get; set; }

    public virtual PurchaseOrderReference PurchaseOrderReference { get; set; }

    public virtual OfferReference OfferReference { get; set; }
}