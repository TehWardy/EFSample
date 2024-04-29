using B2B.Objects.Entities.Masterdata;

namespace B2B.Objects.Entities.Payments;

public class RemittanceAdviceCompany
{
    public string Id { get; set; }

    public string Perspective { get; set; }

    public string CompanyReferenceId { get; set; }

    public Guid RemittanceAdviceId { get; set; }

    public virtual CompanyReference CompanyReference { get; set; }

    public virtual RemittanceAdvice RemittanceAdvice { get; set; }
}