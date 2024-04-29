using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Payments;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class RemittanceAdviceCompanyBroker : IRemittanceAdviceCompanyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public RemittanceAdviceCompanyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<RemittanceAdviceCompany> AddRemittanceAdviceCompanyAsync(RemittanceAdviceCompany remittanceAdviceCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.RemittanceAdviceCompanies.AddAsync(remittanceAdviceCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<RemittanceAdviceCompany> UpdateRemittanceAdviceCompanyAsync(RemittanceAdviceCompany remittanceAdviceCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.RemittanceAdviceCompanies.Update(remittanceAdviceCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteRemittanceAdviceCompanyAsync(RemittanceAdviceCompany remittanceAdviceCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.RemittanceAdviceCompanies.Remove(remittanceAdviceCompany);
            await context.SaveChangesAsync();
        }

        public IQueryable<RemittanceAdviceCompany> GetAllRemittanceAdviceCompanies(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.RemittanceAdviceCompanies.IgnoreQueryFilters()
                : readContext.RemittanceAdviceCompanies;
        }
    }
}