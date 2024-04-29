using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketCreditBroker
    {
        ValueTask<BucketCredit> AddBucketCreditAsync(BucketCredit userRole);
        ValueTask<BucketCredit> UpdateBucketCreditAsync(BucketCredit userRole);
        ValueTask DeleteBucketCreditAsync(BucketCredit userRole);
        IQueryable<BucketCredit> GetAllBucketCredits(bool ignoreFilters = false);
    }
}
