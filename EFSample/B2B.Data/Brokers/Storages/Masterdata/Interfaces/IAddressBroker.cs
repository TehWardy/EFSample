using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IAddressBroker
    {
        ValueTask<Address> AddAddressAsync(Address userRole);
        ValueTask<Address> UpdateAddressAsync(Address userRole);
        ValueTask DeleteAddressAsync(Address userRole);
        IQueryable<Address> GetAllAddresss();
    }
}