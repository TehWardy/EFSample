using B2B.Data.Brokers.Storages.Funding.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Funding.Offer;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Funding
{
    public class OfferLineBroker : IOfferLineBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public OfferLineBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<OfferLine> AddOfferLineAsync(OfferLine offerLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.OfferLines.AddAsync(offerLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<OfferLine> UpdateOfferLineAsync(OfferLine offerLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.OfferLines.Update(offerLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteOfferLineAsync(OfferLine offerLine)
        {
            using var context = contextFactory.CreateDbContext();
            context.OfferLines.Remove(offerLine);
            await context.SaveChangesAsync();
        }

        public IQueryable<OfferLine> GetAllOfferLines(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.OfferLines.IgnoreQueryFilters()
                : readContext.OfferLines;
        }

        public bool InvoiceReferenceExists(string invoiceReference)
        {
            readContext ??= contextFactory.CreateDbContext();

            return readContext.InvoiceReferences
                .IgnoreQueryFilters()
                .Any(ir => ir.Id == invoiceReference);
        }

        public bool CreditReferenceExists(string creditReference)
        {
            readContext ??= contextFactory.CreateDbContext();

            return readContext.CreditReferences
                .IgnoreQueryFilters()
                .Any(ir => ir.Id == creditReference);
        }

        public bool RemittanceAdviceReferenceExists(string remittanceAdviceReference)
        {
            readContext ??= contextFactory.CreateDbContext();

            return readContext.RemittanceAdviceReferences
                .IgnoreQueryFilters()
                .Any(ir => ir.Id == remittanceAdviceReference);
        }
    }
}