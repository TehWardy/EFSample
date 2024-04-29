namespace B2B.Objects.DTOs
{
    public class FundingSummary
    {
        public int FundingDetailId { get; set; }
        public string Scheme { get; set; }
        public string Description { get; set; }
        public string Formula { get; set; }
        public bool IsSystematic { get; set; }
    }
}
