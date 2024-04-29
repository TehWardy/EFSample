using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketRemittanceAdviceBroker
    {
        ValueTask<BucketRemittanceAdvice> AddBucketRemittanceAdviceAsync(BucketRemittanceAdvice userRole);
        ValueTask<BucketRemittanceAdvice> UpdateBucketRemittanceAdviceAsync(BucketRemittanceAdvice userRole);
        ValueTask DeleteBucketRemittanceAdviceAsync(BucketRemittanceAdvice userRole);
        IQueryable<BucketRemittanceAdvice> GetAllBucketRemittanceAdvices(bool ignoreFilters = false);
    }
}
