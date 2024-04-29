using B2B.Data.Brokers.Storages.Security.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Security;

namespace B2B.Data.Brokers.Storages.Security
{
    public class B2BUserRoleBroker : IB2BUserRoleBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public B2BUserRoleBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<B2BUserRole> AddB2BUserRoleAsync(B2BUserRole userRole)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.UserRoles.AddAsync(userRole);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteB2BUserRoleAsync(B2BUserRole userRole)
        {
            using var context = contextFactory.CreateDbContext();
            context.UserRoles.Remove(userRole);
            await context.SaveChangesAsync();
        }

        public IQueryable<B2BUserRole> GetAllB2BUserRoles()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.UserRoles;
        }
    }
}