using B2B.Objects.Entities.Funding.Offer;

namespace B2B.Data.Brokers.Storages.Funding.Interfaces;

public interface IOfferBroker
{
    IQueryable<Offer> GetAllOffers(bool ignoreFilters = false, bool loadChildren = false);

    ValueTask<Offer> AddOfferAsync(Offer offer);
    ValueTask<IEnumerable<Offer>> AddAllOffersAsync(IEnumerable<Offer> offers);
    ValueTask<Offer> UpdateOfferAsync(Offer offer);
    ValueTask DeleteOfferAsync(Offer offer);
    ValueTask DeleteAllOffersForSystem(string sourceSystemId);
    ValueTask DeleteAllOffersAsync(IEnumerable<Offer> offers);


    IEnumerable<Guid> ComputeBuckets(string[] invoiceRefs, string[] creditRefs);
    IEnumerable<(string companyReferenceId, string perspective)> GetCompanies(string[] invoiceRefs, string[] creditRefs);
}