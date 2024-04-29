using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface ICurrencyBroker
    {
        IQueryable<Currency> GetAllCurrencies();
    }
}