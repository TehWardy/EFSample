using B2B.Data.Brokers.Storages.Auditing.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Logging;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Auditing;

public class OfferAuditItemBroker(
    IB2BDbContextFactory contextFactory) : IOfferAuditItemBroker
{
    private B2BDbContext readContext;

    public IQueryable<OfferAuditItem> GetAllOfferAuditItems(bool ignoreFilters = false)
    {
        readContext ??= contextFactory.CreateDbContext();

        return ignoreFilters
            ? readContext.OfferAuditItems.IgnoreQueryFilters()
            : readContext.OfferAuditItems;
    }

    public async ValueTask<OfferAuditItem> AddOfferAuditItemAsync(OfferAuditItem offerAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.OfferAuditItems.AddAsync(offerAuditItem);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<IEnumerable<OfferAuditItem>> AddAllOfferAuditItemsAsync(IEnumerable<OfferAuditItem> items)
    {
        using var context = contextFactory.CreateDbContext();

        await context.OfferAuditItems.AddRangeAsync(items);
        await context.SaveChangesAsync();

        return items;
    }

    public async ValueTask DeleteOfferAuditItemAsync(OfferAuditItem offerAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        context.OfferAuditItems.Remove(offerAuditItem);
        await context.SaveChangesAsync();
    }
}