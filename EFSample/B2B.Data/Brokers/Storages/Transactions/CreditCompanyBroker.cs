using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class CreditCompanyBroker : ICreditCompanyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CreditCompanyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<CreditCompany> AddCreditCompanyAsync(CreditCompany creditCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.CreditCompanies.AddAsync(creditCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<CreditCompany> UpdateCreditCompanyAsync(CreditCompany creditCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.CreditCompanies.Update(creditCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteCreditCompanyAsync(CreditCompany creditCompany)
        {
            using var context = contextFactory.CreateDbContext();
            context.CreditCompanies.Remove(creditCompany);
            await context.SaveChangesAsync();
        }

        public IQueryable<CreditCompany> GetAllCreditCompanies(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.CreditCompanies.IgnoreQueryFilters()
                : readContext.CreditCompanies;
        }
    }
}
