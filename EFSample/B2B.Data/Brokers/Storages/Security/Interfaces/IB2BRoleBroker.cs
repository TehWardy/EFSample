using B2B.Objects.Entities.Security;

namespace B2B.Data.Brokers.Storages.Security.Interfaces
{
    public interface IB2BRoleBroker
    {
        ValueTask<B2BRole> AddB2BRoleAsync(B2BRole userRole);
        ValueTask<B2BRole> UpdateB2BRoleAsync(B2BRole userRole);
        ValueTask DeleteB2BRoleAsync(B2BRole userRole);
        IQueryable<B2BRole> GetAllB2BRoles();
    }
}
