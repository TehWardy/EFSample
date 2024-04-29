using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class CreditReferenceBroker : ICreditReferenceBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CreditReferenceBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<CreditReference> AddCreditReferenceAsync(CreditReference creditReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.CreditReferences.AddAsync(creditReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<CreditReference> UpdateCreditReferenceAsync(CreditReference creditReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.CreditReferences.Update(creditReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteCreditReferenceAsync(CreditReference creditReference)
        {
            using var context = contextFactory.CreateDbContext();
            context.CreditReferences.Remove(creditReference);
            await context.SaveChangesAsync();
        }

        public IQueryable<CreditReference> GetAllCreditReferences(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.CreditReferences.IgnoreQueryFilters()
                : readContext.CreditReferences;
        }
    }
}
