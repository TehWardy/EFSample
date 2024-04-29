using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions;

public class InvoiceBroker : IInvoiceBroker
{
    private readonly IB2BDbContextFactory contextFactory;

    public InvoiceBroker(IB2BDbContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async ValueTask<Invoice> AddInvoiceAsync(Invoice invoice)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = await context.Invoices.AddAsync(invoice);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Invoice> UpdateInvoiceAsync(Invoice invoice)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = context.Invoices.Update(invoice);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteInvoiceAsync(Invoice invoice)
    {
        using var context = contextFactory.CreateDbContext();
        context.Invoices.Remove(new Invoice() { Id = invoice.Id });
        await context.SaveChangesAsync();
    }

    public async ValueTask DeleteAllInvoicesForSystem(string sourceSystemId)
    {
        using var context = contextFactory.CreateDbContext();
        await context.DeleteAllInvoicesForSystem(sourceSystemId);
    }

    public bool AnyBucketFundingType(IEnumerable<Guid> bucketIds)
    {
        using var context = contextFactory.CreateDbContext();

        return context.Buckets
            .Any(b => bucketIds.Contains(b.Id) && b.Key == "FundingType");
    }

    public IQueryable<Invoice> GetAllInvoices(bool ignoreFilters = false, bool loadChildren = false)
    {
        var context = contextFactory.CreateDbContext();

        var result = (ignoreFilters)
            ? context.Invoices.IgnoreQueryFilters()
            : context.Invoices;

        if (loadChildren)
            result = result
                .Include(r => r.Companies)
                .Include(r => r.Lines)
                .Include(r => r.References)
                .Include(r => r.Buckets);

        return result;
    }

    public IEnumerable<Guid> ComputeBuckets(Guid rootBucket, string[] buyerRefs, string[] supplierRefs, string[] funderRefs)
    {
        using var context = contextFactory.CreateDbContext();
        return context.ComputeBuckets(rootBucket, buyerRefs, supplierRefs, funderRefs);
    }
}