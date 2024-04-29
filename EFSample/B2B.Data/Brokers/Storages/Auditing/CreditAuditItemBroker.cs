using B2B.Data.Brokers.Storages.Auditing.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Logging;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Auditing;

public class CreditAuditItemBroker(
    IB2BDbContextFactory contextFactory) : ICreditAuditItemBroker
{
    private B2BDbContext readContext;

    public IQueryable<CreditAuditItem> GetAllCreditAuditItems(bool ignoreFilters = false)
    {
        readContext ??= contextFactory.CreateDbContext();
        return ignoreFilters
            ? readContext.CreditAuditItems.IgnoreQueryFilters()
            : readContext.CreditAuditItems;
    }

    public async ValueTask<CreditAuditItem> AddCreditAuditItemAsync(CreditAuditItem creditAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.CreditAuditItems.AddAsync(creditAuditItem);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<IEnumerable<CreditAuditItem>> AddAllCreditAuditItemsAsync(IEnumerable<CreditAuditItem> items)
    {
        using var context = contextFactory.CreateDbContext();

        await context.CreditAuditItems.AddRangeAsync(items);
        await context.SaveChangesAsync();

        return items;
    }

    public async ValueTask DeleteCreditAuditItemAsync(CreditAuditItem creditAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.CreditAuditItems.Remove(creditAuditItem);
        await context.SaveChangesAsync();
    }
}