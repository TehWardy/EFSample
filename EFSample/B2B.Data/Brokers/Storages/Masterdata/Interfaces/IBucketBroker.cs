using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketBroker
    {
        ValueTask<Bucket> AddBucketAsync(Bucket userRole);
        ValueTask<Bucket> UpdateBucketAsync(Bucket userRole);
        ValueTask DeleteBucketAsync(Bucket userRole);
        IQueryable<Bucket> GetAllBuckets(bool ignoreFilters = false);
    }
}
