using B2B.Objects.Entities.Funding;

namespace B2B.Data.Brokers.Storages.Funding.Interfaces
{
    public interface IRateBroker
    {
        ValueTask<Rate> AddRateAsync(Rate rate);
        ValueTask DeleteRateAsync(Rate rate);
        IQueryable<Rate> GetAllRates();
        ValueTask<Rate> UpdateRateAsync(Rate rate);
    }
}