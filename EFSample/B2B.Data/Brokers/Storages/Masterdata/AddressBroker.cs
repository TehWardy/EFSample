using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class AddressBroker : IAddressBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public AddressBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<Address> AddAddressAsync(Address address)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.Addresses.AddAsync(address);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<Address> UpdateAddressAsync(Address address)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.Addresses.Update(address);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteAddressAsync(Address address)
        {
            using var context = contextFactory.CreateDbContext();
            context.Addresses.Remove(address);
            await context.SaveChangesAsync();
        }

        public IQueryable<Address> GetAllAddresss()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.Addresses;
        }
    }
}