using B2B.Objects.Entities.Funding.Offer;

namespace B2B.Data.Brokers.Storages.Funding.Interfaces
{
    public interface IOfferCompanyBroker
    {
        ValueTask<OfferCompany> AddOfferCompanyAsync(OfferCompany offerCompany);
        ValueTask DeleteOfferCompanyAsync(OfferCompany offerCompany);
        IQueryable<OfferCompany> GetAllOfferCompanies(bool ignoreFilters = false);
    }
}