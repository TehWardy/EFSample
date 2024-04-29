using B2B.Data.Brokers.Storages.Masterdata.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Data.Brokers.Storages.Masterdata
{
    public class SystemBroker : ISystemBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public SystemBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<B2BSystem> AddSystemAsync(B2BSystem system)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.Systems.AddAsync(system);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<B2BSystem> UpdateSystemAsync(B2BSystem system)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.Systems.Update(system);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteSystemAsync(B2BSystem system)
        {
            using var context = contextFactory.CreateDbContext();
            context.Systems.Remove(system);
            await context.SaveChangesAsync();
        }

        public IQueryable<B2BSystem> GetAllSystems()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.Systems;
        }
    }
}
