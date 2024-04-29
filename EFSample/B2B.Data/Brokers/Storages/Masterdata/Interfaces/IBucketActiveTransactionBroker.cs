using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketActiveTransactionBroker
    {
        ValueTask<BucketActiveTransaction> AddBucketActiveTransactionAsync(BucketActiveTransaction bucketActiveTransaction);
        ValueTask DeleteBucketActiveTransactionAsync(BucketActiveTransaction bucketActiveTransaction);
        IQueryable<BucketActiveTransaction> GetAllBucketActiveTransactions(bool ignoreFilters = false);
    }
}