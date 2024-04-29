using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing.Interfaces;

public interface IOfferAuditItemBroker
{
    IQueryable<OfferAuditItem> GetAllOfferAuditItems(bool ignoreFilters = false);
    ValueTask<OfferAuditItem> AddOfferAuditItemAsync(OfferAuditItem offerAuditItem);
    ValueTask<IEnumerable<OfferAuditItem>> AddAllOfferAuditItemsAsync(IEnumerable<OfferAuditItem> offerAuditItem);
    ValueTask DeleteOfferAuditItemAsync(OfferAuditItem offerAuditItem);
}