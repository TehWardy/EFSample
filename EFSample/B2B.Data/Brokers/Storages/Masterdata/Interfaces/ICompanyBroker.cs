using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface ICompanyBroker
    {
        IQueryable<Company> GetAllCompanies(bool ignoreFilters = false);
        ValueTask<Company> AddCompanyAsync(Company userRole);
        ValueTask<Company> UpdateCompanyAsync(Company userRole);
        ValueTask DeleteCompanyAsync(Company userRole);
    }
}
