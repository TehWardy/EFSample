using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketBankAccountBroker
    {
        ValueTask<BucketBankAccount> AddBucketBankAccountAsync(BucketBankAccount userRole);
        ValueTask DeleteBucketBankAccountAsync(BucketBankAccount userRole);
        IQueryable<BucketBankAccount> GetAllBucketBankAccounts();
    }
}