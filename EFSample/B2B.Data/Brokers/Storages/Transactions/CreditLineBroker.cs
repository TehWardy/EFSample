using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class CreditLineBroker : ICreditLineBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CreditLineBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<CreditLine> AddCreditLineAsync(CreditLine creditLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.CreditLines.AddAsync(creditLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<CreditLine> UpdateCreditLineAsync(CreditLine creditLine)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.CreditLines.Update(creditLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteCreditLineAsync(CreditLine creditLine)
        {
            using var context = contextFactory.CreateDbContext();
            context.CreditLines.Remove(creditLine);
            await context.SaveChangesAsync();
        }

        public IQueryable<CreditLine> GetAllCreditLines(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.CreditLines.IgnoreQueryFilters()
                : readContext.CreditLines;
        }
    }
}