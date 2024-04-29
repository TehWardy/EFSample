using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class InvoiceReferenceBroker : IInvoiceReferenceBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public InvoiceReferenceBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<InvoiceReference> AddInvoiceReferenceAsync(InvoiceReference invoiceReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.InvoiceReferences.AddAsync(invoiceReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<InvoiceReference> UpdateInvoiceReferenceAsync(InvoiceReference invoiceReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.InvoiceReferences.Update(invoiceReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteInvoiceReferenceAsync(InvoiceReference invoiceReference)
        {
            using var context = contextFactory.CreateDbContext();
            context.InvoiceReferences.Remove(invoiceReference);
            await context.SaveChangesAsync();
        }

        public IQueryable<InvoiceReference> GetAllInvoiceReferences(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.InvoiceReferences.IgnoreQueryFilters()
                : readContext.InvoiceReferences;
        }
    }
}