using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketOfferBroker
    {
        ValueTask<BucketOffer> AddBucketOfferAsync(BucketOffer userRole);
        ValueTask<BucketOffer> UpdateBucketOfferAsync(BucketOffer userRole);
        ValueTask DeleteBucketOfferAsync(BucketOffer userRole);
        IQueryable<BucketOffer> GetAllBucketOffers(bool ignoreFilters = false);
    }
}
