using B2B.Objects.Entities.Funding.Offer;

namespace B2B.Data.Brokers.Storages.Funding.Interfaces
{
    public interface IOfferReferenceBroker
    {
        ValueTask<OfferReference> AddOfferReferenceAsync(OfferReference offerReference);
        ValueTask DeleteOfferReferenceAsync(OfferReference offerReference);
        ValueTask<OfferReference> UpdateOfferReferenceAsync(OfferReference offerReference);
        IQueryable<OfferReference> GetAllOfferReferences(bool ignoreFilters = false);
    }
}