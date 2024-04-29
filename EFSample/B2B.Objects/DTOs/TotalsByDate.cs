namespace B2B.Objects.DTOs
{
    public class TotalsByDate
    {
        public string Currency { get; set; }
        public string DateUsed { get; set; }
        public string CalendarMonth { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public decimal Average { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}