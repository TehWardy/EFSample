using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class CompanyBroker : ICompanyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;

        public CompanyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<Company> AddCompanyAsync(Company Company)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.Companies.AddAsync(Company);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<Company> UpdateCompanyAsync(Company Company)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.Companies.Update(Company);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteCompanyAsync(Company Company)
        {
            using var context = contextFactory.CreateDbContext();
            context.Companies.Remove(Company);
            await context.SaveChangesAsync();
        }

        public IQueryable<Company> GetAllCompanies(bool ignoreFilters = false)
        {
            var context = contextFactory.CreateDbContext();

            return ignoreFilters
                ? context.Companies.IgnoreQueryFilters()
                : context.Companies;
        }
    }
}