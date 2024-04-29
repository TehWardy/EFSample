using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface ICompanyReferenceBroker
    {
        ValueTask<CompanyReference> AddCompanyReferenceAsync(CompanyReference userRole);
        ValueTask<CompanyReference> UpdateCompanyReferenceAsync(CompanyReference userRole);
        ValueTask DeleteCompanyReferenceAsync(CompanyReference userRole);
        IQueryable<CompanyReference> GetAllCompanyReferences(bool unfiltered = false);
    }
}
