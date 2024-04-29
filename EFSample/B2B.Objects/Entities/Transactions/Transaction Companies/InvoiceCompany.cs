using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities;

public class InvoiceCompany
{
    public string Id { get; set; }

    public string Perspective { get; set; }

    public string CompanyReferenceId { get; set; }

    public Guid InvoiceId { get; set; }

    public virtual CompanyReference CompanyReference { get; set; }

    public virtual Invoice Invoice { get; set; }
}