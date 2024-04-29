using B2B.Objects.Entities.Funding;

namespace B2B.Objects.DTOs;

public class FundingTypeBucketDetails
{
    public string Key { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string[] Companies { get; set; }
    public FundingDetail[] FundingDetails { get; set; }
}
