using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Transactions;

namespace B2B.Objects.Entities;

public class CreditCompany
{
    public string Id { get; set; }

    public string Perspective { get; set; }

    public string CompanyReferenceId { get; set; }

    public Guid CreditId { get; set; }

    public virtual CompanyReference CompanyReference { get; set; }

    public virtual Credit Credit { get; set; }
}