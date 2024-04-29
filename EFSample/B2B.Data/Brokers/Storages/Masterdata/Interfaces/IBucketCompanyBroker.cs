using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketCompanyBroker
    {
        ValueTask<BucketCompany> AddBucketCompanyAsync(BucketCompany userRole);
        ValueTask DeleteBucketCompanyAsync(BucketCompany userRole);
        IQueryable<BucketCompany> GetAllBucketCompanies();
    }
}
