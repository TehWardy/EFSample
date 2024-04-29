using B2B.Data.Brokers.Storages.Auditing.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing;

public class InvoiceAuditItemBroker(
    IB2BDbContextFactory contextFactory) : IInvoiceAuditItemBroker
{
    private B2BDbContext readContext;

    public IQueryable<InvoiceAuditItem> GetAllInvoiceAuditItems()
    {
        readContext ??= contextFactory.CreateDbContext();
        return readContext.InvoiceAuditItems;
    }

    public async ValueTask<InvoiceAuditItem> AddInvoiceAuditItemAsync(InvoiceAuditItem invoiceAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.InvoiceAuditItems.AddAsync(invoiceAuditItem);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<IEnumerable<InvoiceAuditItem>> AddAllInvoiceAuditItemsAsync(IEnumerable<InvoiceAuditItem> items)
    {
        using var context = contextFactory.CreateDbContext();

        await context.InvoiceAuditItems.AddRangeAsync(items);
        await context.SaveChangesAsync();

        return items;
    }

    public async ValueTask DeleteInvoiceAuditItemAsync(InvoiceAuditItem invoiceAuditItem)
    {
        using var context = contextFactory.CreateDbContext();

        context.InvoiceAuditItems.Remove(invoiceAuditItem);
        await context.SaveChangesAsync();
    }
}