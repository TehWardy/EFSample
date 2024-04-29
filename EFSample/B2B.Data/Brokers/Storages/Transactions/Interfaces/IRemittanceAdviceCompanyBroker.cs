using B2B.Objects.Entities.Payments;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IRemittanceAdviceCompanyBroker
    {
        ValueTask<RemittanceAdviceCompany> AddRemittanceAdviceCompanyAsync(RemittanceAdviceCompany remittanceAdviceCompany);
        ValueTask DeleteRemittanceAdviceCompanyAsync(RemittanceAdviceCompany remittanceAdviceCompany);
        IQueryable<RemittanceAdviceCompany> GetAllRemittanceAdviceCompanies(bool ignoreFilters = false);
        ValueTask<RemittanceAdviceCompany> UpdateRemittanceAdviceCompanyAsync(RemittanceAdviceCompany remittanceAdviceCompany);
    }
}