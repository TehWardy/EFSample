using B2B.Objects.Entities.Import;

namespace B2B.Data.Brokers.Storages.Import.Interfaces
{
    public interface ICompanyCSVLineBroker
    {
        ValueTask<CompanyCSVLine> AddCompanyCSVLineAsync(CompanyCSVLine companyCSVLine);
        ValueTask DeleteCompanyCSVLineAsync(CompanyCSVLine companyCSVLine);
        IQueryable<CompanyCSVLine> GetAllCompanyCSVLines();
        ValueTask<CompanyCSVLine> UpdateCompanyCSVLineAsync(CompanyCSVLine companyCSVLine);
    }
}