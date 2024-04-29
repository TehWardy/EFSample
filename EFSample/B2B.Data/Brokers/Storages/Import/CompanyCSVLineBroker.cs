using B2B.Data.Brokers.Storages.Import.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Import;

namespace B2B.Data.Brokers.Storages.Import
{
    public class CompanyCSVLineBroker : ICompanyCSVLineBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CompanyCSVLineBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<CompanyCSVLine> AddCompanyCSVLineAsync(CompanyCSVLine companyCSVLine)
        {
            using var context = contextFactory.CreateDbContext();

            var entityEntry = await context.CompanyCSVLines.AddAsync(companyCSVLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<CompanyCSVLine> UpdateCompanyCSVLineAsync(CompanyCSVLine companyCSVLine)
        {
            using var context = contextFactory.CreateDbContext();

            var entityEntry = context.CompanyCSVLines.Update(companyCSVLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteCompanyCSVLineAsync(CompanyCSVLine companyCSVLine)
        {
            using var context = contextFactory.CreateDbContext();

            var entityEntry = context.CompanyCSVLines.Remove(companyCSVLine);
            await context.SaveChangesAsync();
        }

        public IQueryable<CompanyCSVLine> GetAllCompanyCSVLines()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.CompanyCSVLines;
        }
    }
}