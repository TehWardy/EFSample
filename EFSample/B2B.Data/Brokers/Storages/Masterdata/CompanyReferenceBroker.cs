using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class CompanyReferenceBroker : ICompanyReferenceBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public CompanyReferenceBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<CompanyReference> AddCompanyReferenceAsync(CompanyReference CompanyReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.CompanyReferences.AddAsync(CompanyReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<CompanyReference> UpdateCompanyReferenceAsync(CompanyReference CompanyReference)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.CompanyReferences.Update(CompanyReference);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteCompanyReferenceAsync(CompanyReference CompanyReference)
        {
            using var context = contextFactory.CreateDbContext();
            context.CompanyReferences.Remove(CompanyReference);
            await context.SaveChangesAsync();
        }

        public IQueryable<CompanyReference> GetAllCompanyReferences(bool ignoreFilters = false)
        {
            readContext ??= contextFactory.CreateDbContext();

            return ignoreFilters
                ? readContext.CompanyReferences.IgnoreQueryFilters()
                : readContext.CompanyReferences;
        }
    }
}
