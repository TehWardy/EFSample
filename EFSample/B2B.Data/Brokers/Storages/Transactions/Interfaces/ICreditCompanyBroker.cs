using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface ICreditCompanyBroker
    {
        ValueTask<CreditCompany> AddCreditCompanyAsync(CreditCompany creditCompany);
        ValueTask DeleteCreditCompanyAsync(CreditCompany creditCompany);
        IQueryable<CreditCompany> GetAllCreditCompanies(bool ignoreFilters = false);
        ValueTask<CreditCompany> UpdateCreditCompanyAsync(CreditCompany creditCompany);
    }
}