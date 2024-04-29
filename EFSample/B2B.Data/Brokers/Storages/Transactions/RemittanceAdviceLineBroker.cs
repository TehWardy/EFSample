using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Payments;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class RemittanceAdviceLineBroker : IRemittanceAdviceLineBroker
    {
        private readonly IB2BDbContextFactory contextFactory;

        public RemittanceAdviceLineBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<RemittanceAdviceLine> AddRemittanceAdviceLineAsync(RemittanceAdviceLine remittanceAdviceLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.RemittanceAdviceLines.AddAsync(remittanceAdviceLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<RemittanceAdviceLine> UpdateRemittanceAdviceLineAsync(RemittanceAdviceLine remittanceAdviceLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.RemittanceAdviceLines.Update(remittanceAdviceLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteRemittanceAdviceLineAsync(RemittanceAdviceLine remittanceAdviceLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.RemittanceAdviceLines.Remove(remittanceAdviceLine);
            await context.SaveChangesAsync();
        }

        public IQueryable<RemittanceAdviceLine> GetAllRemittanceAdviceLines(bool ignoreFilters = false)
        {
            var readContext = contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.RemittanceAdviceLines.IgnoreQueryFilters()
                : readContext.RemittanceAdviceLines;
        }

        public bool InvoiceReferenceExists(string invoiceReference)
        {
            using var readContext = contextFactory.CreateDbContext();

            return readContext.InvoiceReferences
                .IgnoreQueryFilters()
                .Any(ir => ir.Id == invoiceReference);
        }

        public bool CreditReferenceExists(string creditReference)
        {
            using var readContext = contextFactory.CreateDbContext();

            return readContext.CreditReferences
                .IgnoreQueryFilters()
                .Any(ir => ir.Id == creditReference);
        }

        public bool OfferReferenceExists(string offerReference)
        {
            using var readContext = contextFactory.CreateDbContext();

            return readContext.OfferReferences
                .IgnoreQueryFilters()
                .Any(ir => ir.Id == offerReference);
        }
    }
}