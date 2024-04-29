namespace B2B.Objects.DTOs;

public class FunderBucketDetail
{
    public string Key { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ParentId { get; set; }
    public string[] Companies { get; set; }
    public FundingTypeBucketDetails[] Buckets { get; set; }
}