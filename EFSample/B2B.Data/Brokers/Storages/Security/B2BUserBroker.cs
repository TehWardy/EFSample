using B2B.Data.Brokers.Storages.Security.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Security;

public class B2BUserBroker : IB2BUserBroker
{
    private readonly IB2BDbContextFactory contextFactory;
    private B2BDbContext readContext;

    public B2BUserBroker(IB2BDbContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async ValueTask<B2BUser> AddB2BUserAsync(B2BUser User)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = await context.Users.AddAsync(User);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<B2BUser> UpdateB2BUserAsync(B2BUser User)
    {
        using var context = contextFactory.CreateDbContext();
        var resultEntity = context.Users.Update(User).Entity;
        await context.SaveChangesAsync();

        return resultEntity;
    }

    public async ValueTask DeleteB2BUserAsync(B2BUser User)
    {
        using var context = contextFactory.CreateDbContext();
        context.Users.Remove(User);
        await context.SaveChangesAsync();
    }

    public IQueryable<B2BUser> GetAllB2BUsers(bool ignoreFilters = false)
    {
        readContext ??= contextFactory.CreateDbContext();

        return ignoreFilters
            ? readContext.Users.IgnoreQueryFilters()
            : readContext.Users;
    }

    public B2BUser GetCurrentUser()
    {
        readContext ??= contextFactory.CreateDbContext();
        return readContext.GetCurrentUser();
    }
}