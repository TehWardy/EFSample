namespace B2B.Objects.Entities.Funding
{
    public class Rate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset AppliesFrom { get; set; }
        public decimal Value { get; set; }
    }
}