using B2B.Data.Brokers.Storages.Auditing.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Logging;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Auditing;

public class RemittanceAdviceAuditItemBroker(IB2BDbContextFactory contextFactory) : IRemittanceAdviceAuditItemBroker
{
    private B2BDbContext readContext;

    public IQueryable<RemittanceAdviceAuditItem> GetAllRemittanceAdviceAuditItems(bool ignoreFilters = false)
    {
        readContext ??= contextFactory.CreateDbContext();

        return ignoreFilters
            ? readContext.RemittanceAdviceAuditItems.IgnoreQueryFilters()
            : readContext.RemittanceAdviceAuditItems;
    }

    public async ValueTask<RemittanceAdviceAuditItem> AddRemittanceAdviceAuditItemAsync(RemittanceAdviceAuditItem remittanceAdviceAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.RemittanceAdviceAuditItems.AddAsync(remittanceAdviceAuditItem);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<IEnumerable<RemittanceAdviceAuditItem>> AddAllRemittanceAdviceAuditItemsAsync(IEnumerable<RemittanceAdviceAuditItem> items)
    {
        using var context = contextFactory.CreateDbContext();

        await context.RemittanceAdviceAuditItems.AddRangeAsync(items);
        await context.SaveChangesAsync();

        return items;
    }

    public async ValueTask DeleteRemittanceAdviceAuditItemAsync(RemittanceAdviceAuditItem remittanceAdviceAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.RemittanceAdviceAuditItems.Remove(remittanceAdviceAuditItem);
        await context.SaveChangesAsync();
    }
}