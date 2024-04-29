using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class BucketRoleBroker(IB2BDbContextFactory contextFactory) : IBucketRoleBroker
    {
        public async ValueTask<BucketRole> AddBucketRoleAsync(BucketRole BucketRole)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.BucketRoles.AddAsync(BucketRole);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteBucketRoleAsync(BucketRole BucketRole)
        {
            using var context = contextFactory.CreateDbContext();
            context.BucketRoles.Remove(BucketRole);
            await context.SaveChangesAsync();
        }

        public IQueryable<BucketRole> GetAllBucketRoles(bool ignoreFilters = false) =>
            ignoreFilters
                ? contextFactory.CreateDbContext().BucketRoles.IgnoreQueryFilters()
                : contextFactory.CreateDbContext().BucketRoles;
    }
}