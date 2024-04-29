using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketRoleBroker
    {
        ValueTask<BucketRole> AddBucketRoleAsync(BucketRole userRole);
        ValueTask DeleteBucketRoleAsync(BucketRole userRole);
        IQueryable<BucketRole> GetAllBucketRoles(bool ignoreFilters = false);
    }
}
