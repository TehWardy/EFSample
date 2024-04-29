namespace B2B.Objects.DTOs
{
    public class GenerateOfferParams
    {
        public ICollection<string> Transactions { get; set; }
        public ICollection<string> References { get; set; }
        public decimal Value { get; set; }
        public string CurrencyId { get; set; }
        public DateTimeOffset Expires { get; set; }
        public string SourceSystemId { get; set; }
        public DateTimeOffset FunderPaymentDate { get; set; }
    }
}

