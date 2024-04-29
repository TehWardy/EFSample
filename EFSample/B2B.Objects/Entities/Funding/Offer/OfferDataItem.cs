namespace B2B.Objects.Entities.Funding.Offer
{
    public class OfferDataItem
    {
        public Guid Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public Guid OfferId { get; set; }

        public virtual Offer Offer { get; set; }
    }
}