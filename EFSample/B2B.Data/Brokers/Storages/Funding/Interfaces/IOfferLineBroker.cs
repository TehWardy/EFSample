using B2B.Objects.Entities.Funding.Offer;

namespace B2B.Data.Brokers.Storages.Funding.Interfaces
{
    public interface IOfferLineBroker
    {
        ValueTask<OfferLine> AddOfferLineAsync(OfferLine offerLine);
        ValueTask DeleteOfferLineAsync(OfferLine offerLine);
        IQueryable<OfferLine> GetAllOfferLines(bool ignoreFilters = false);
        ValueTask<OfferLine> UpdateOfferLineAsync(OfferLine offerLine);

        bool InvoiceReferenceExists(string invoiceReference);
        bool CreditReferenceExists(string creditReference);
        bool RemittanceAdviceReferenceExists(string remittanceAdviceReference);
    }
}