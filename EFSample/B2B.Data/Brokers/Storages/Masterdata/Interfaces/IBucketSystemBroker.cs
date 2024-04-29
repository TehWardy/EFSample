using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketSystemBroker
    {
        ValueTask<BucketSystem> AddBucketSystemAsync(BucketSystem bucketSystem);
        ValueTask DeleteBucketSystemAsync(BucketSystem bucketSystem);
        IQueryable<BucketSystem> GetAllBucketSystems();
    }
}
