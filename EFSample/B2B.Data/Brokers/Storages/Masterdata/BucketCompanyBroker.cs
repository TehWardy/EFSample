using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketCompanyBroker : IBucketCompanyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public BucketCompanyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<BucketCompany> AddBucketCompanyAsync(BucketCompany BucketCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketCompanies.AddAsync(BucketCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketCompanyAsync(BucketCompany BucketCompany)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketCompanies.Remove(BucketCompany);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketCompany> GetAllBucketCompanies()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.BucketCompanies;
        }
    }
}
