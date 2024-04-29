using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class InvoiceLineBroker : IInvoiceLineBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public InvoiceLineBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<InvoiceLine> AddInvoiceLineAsync(InvoiceLine invoiceLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.InvoiceLines.AddAsync(invoiceLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<InvoiceLine> UpdateInvoiceLineAsync(InvoiceLine invoiceLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.InvoiceLines.Update(invoiceLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteInvoiceLineAsync(InvoiceLine invoiceLine)
        {
            using var context = contextFactory.CreateDbContext();
            context.InvoiceLines.Remove(invoiceLine);
            await context.SaveChangesAsync();
        }

        public IQueryable<InvoiceLine> GetAllInvoiceLines(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.InvoiceLines.IgnoreQueryFilters()
                : readContext.InvoiceLines;
        }
    }
}