using B2B.Data.Brokers.Storages.Security.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Security;

namespace B2B.Data.Brokers.Storages.Security
{
    public class B2BRoleBroker : IB2BRoleBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public B2BRoleBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;
        public async ValueTask<B2BRole> AddB2BRoleAsync(B2BRole role)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<B2BRole> UpdateB2BRoleAsync(B2BRole role)
        {
            using var context = contextFactory.CreateDbContext();
            var resultEntity = context.Roles.Update(role).Entity;
            await context.SaveChangesAsync();

            return resultEntity;
        }

        public async ValueTask DeleteB2BRoleAsync(B2BRole role)
        {
            using var context = contextFactory.CreateDbContext();
            context.Roles.Remove(role);
            await context.SaveChangesAsync();
        }

        public IQueryable<B2BRole> GetAllB2BRoles()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.Roles;
        }
    }
}