using B2B.Objects.Entities.Security;

namespace B2B.Data.Brokers.Storages.Security.Interfaces
{
    public interface IB2BUserRoleBroker
    {
        ValueTask<B2BUserRole> AddB2BUserRoleAsync(B2BUserRole userRole);
        ValueTask DeleteB2BUserRoleAsync(B2BUserRole userRole);
        IQueryable<B2BUserRole> GetAllB2BUserRoles();
    }
}