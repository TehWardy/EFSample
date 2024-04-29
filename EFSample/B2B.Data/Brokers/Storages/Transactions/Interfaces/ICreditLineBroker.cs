using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface ICreditLineBroker
    {
        ValueTask<CreditLine> AddCreditLineAsync(CreditLine creditLine);
        ValueTask DeleteCreditLineAsync(CreditLine creditLine);
        IQueryable<CreditLine> GetAllCreditLines(bool ignoreFilters = false);
        ValueTask<CreditLine> UpdateCreditLineAsync(CreditLine creditLine);
    }
}