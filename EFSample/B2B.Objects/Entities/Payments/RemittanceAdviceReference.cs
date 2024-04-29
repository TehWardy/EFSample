using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Objects.Entities.Payments;

public class RemittanceAdviceReference
{
    public string Id { get; set; }

    public string Value { get; set; }

    public string SystemId { get; set; }

    public Guid RemittanceAdviceId { get; set; }

    public virtual B2BSystem System { get; set; }

    public virtual RemittanceAdvice RemittanceAdvice { get; set; }
}