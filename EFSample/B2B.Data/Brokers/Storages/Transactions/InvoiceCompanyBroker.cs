using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class InvoiceCompanyBroker : IInvoiceCompanyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public InvoiceCompanyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<InvoiceCompany> AddInvoiceCompanyAsync(InvoiceCompany invoiceCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.InvoiceCompanies.AddAsync(invoiceCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<InvoiceCompany> UpdateInvoiceCompanyAsync(InvoiceCompany invoiceCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.InvoiceCompanies.Update(invoiceCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteInvoiceCompanyAsync(InvoiceCompany invoiceCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.InvoiceCompanies.Remove(invoiceCompany);
            await context.SaveChangesAsync();
        }

        public IQueryable<InvoiceCompany> GetAllInvoiceCompanies(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.InvoiceCompanies.IgnoreQueryFilters()
                : readContext.InvoiceCompanies;
        }
    }
}