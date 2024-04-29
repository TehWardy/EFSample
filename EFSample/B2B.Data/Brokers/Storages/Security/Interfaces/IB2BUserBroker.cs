using B2B.Objects.Entities.Security;

namespace B2B.Data.Brokers.Storages.Security.Interfaces;

public interface IB2BUserBroker
{
    ValueTask<B2BUser> AddB2BUserAsync(B2BUser user);
    ValueTask<B2BUser> UpdateB2BUserAsync(B2BUser user);
    ValueTask DeleteB2BUserAsync(B2BUser user);

    IQueryable<B2BUser> GetAllB2BUsers(bool ignoreFilters = false);
    B2BUser GetCurrentUser();
}
