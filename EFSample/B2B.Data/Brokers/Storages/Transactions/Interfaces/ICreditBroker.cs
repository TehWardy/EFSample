using B2B.Objects.Entities.Transactions;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces;

public interface ICreditBroker
{
    ValueTask<Credit> AddCreditAsync(Credit credit);
    ValueTask DeleteCreditAsync(Credit credit);

    IQueryable<Credit> GetAllCredits(bool ignoreFilters = false, bool loadChildren = false);
    ValueTask<Credit> UpdateCreditAsync(Credit credit);
    ValueTask DeleteAllCreditsForSystem(string sourceSystemId);

    IEnumerable<Guid> ComputeBuckets(Guid rootBucket, string[] buyerRefs, string[] supplierRefs, string[] funderRefs);
    bool AnyBucketFundingType(IEnumerable<Guid> bucketIds);
}