using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Payments;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class RemittanceAdviceReferenceBroker : IRemittanceAdviceReferenceBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public RemittanceAdviceReferenceBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<RemittanceAdviceReference> AddRemittanceAdviceReferenceAsync(RemittanceAdviceReference remittanceAdviceReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.RemittanceAdviceReferences.AddAsync(remittanceAdviceReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<RemittanceAdviceReference> UpdateRemittanceAdviceReferenceAsync(RemittanceAdviceReference remittanceAdviceReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.RemittanceAdviceReferences.Update(remittanceAdviceReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteRemittanceAdviceReferenceAsync(RemittanceAdviceReference remittanceAdviceReference)
        {
            using var context = contextFactory.CreateDbContext();
            context.RemittanceAdviceReferences.Remove(remittanceAdviceReference);
            await context.SaveChangesAsync();
        }

        public IQueryable<RemittanceAdviceReference> GetAllRemittanceAdviceReferences(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
               ? readContext.RemittanceAdviceReferences.IgnoreQueryFilters()
                : readContext.RemittanceAdviceReferences;
        }
    }
}