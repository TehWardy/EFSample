using B2B.Objects.Entities.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Security;

namespace B2B.Data.EF;

public partial class B2BDbContext
{
    // Security primary entities
    public DbSet<B2BUser> Users { get; set; }
    public DbSet<B2BRole> Roles { get; set; }

    // Security secondary entities
    public DbSet<B2BUserRole> UserRoles { get; set; }

    private static readonly ConcurrentDictionary<string, (B2BUser user, DateTimeOffset expires)> loadedUsers = new();

    private void ApplySecurityFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<B2BUser>().HasQueryFilter(u => UserIsPortalAdmin || u.Id == AuthInfo.SSOUserId);
        modelBuilder.Entity<B2BRole>().HasQueryFilter(r => UserIsPortalAdmin || r.Users.Any());
        modelBuilder.Entity<B2BUserRole>().HasQueryFilter(r => UserIsPortalAdmin || r.UserId == AuthInfo.SSOUserId);
    }

    public static B2BPrivilege[] GetAllPrivileges() => Privileges
        .Select(p =>
        {
            p.Type = p.Id.Split('_')[0];
            p.Operation = p.Id.Split('_').Last();
            p.Description = $"Allows users to perform {p.Operation} operations on {p.Type} entities.";
            return p;
        })
        .ToArray();

    protected Guid[] CurrentUserRoles => GetCurrentUser()
        .Roles
        .Select(r => r.RoleId)
        .ToArray();

    protected bool UserIsPortalAdmin => GetCurrentUser()
        .Roles
        .Any(r => r.Role.UsersArePortalAdmins);

    public B2BUser GetCurrentUser()
    {
        var expiredUsers = loadedUsers
            .Where(u => u.Value.expires < DateTimeOffset.UtcNow)
            .ToArray();

        foreach (var expiredUser in expiredUsers)
            loadedUsers.TryRemove(expiredUser);

        return GetAndCacheUser(AuthInfo.SSOUserId ?? "Guest");
    }

    private B2BUser GetAndCacheUser(string userId)
    {
        if (string.IsNullOrEmpty(userId))
            userId = "Guest";

        (B2BUser user, DateTimeOffset expires) cacheEntry;

        if (!loadedUsers.TryGetValue(userId, out cacheEntry))
        {
            var user = Users
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Include(u => u.Roles)
                    .ThenInclude(ur => ur.Role)
                .AsSplitQuery()
                .FirstOrDefault(u => u.Id == userId)
                    ??
                new B2BUser() { Id = "Guest", Roles = [] };

            cacheEntry = (user, DateTimeOffset.UtcNow.AddMinutes(5));

            loadedUsers.TryAdd(userId, cacheEntry);
        }

        cacheEntry.expires = DateTimeOffset.UtcNow.AddMinutes(5);
        return cacheEntry.user;
    }

    public void UserIsPortalAdminWithPrivilege(string privilege) =>
        UserIsPortalAdminWithPrivilege(privilege, true);

    public void UserIsPortalAdminWithPrivilege(string privilege, bool retry)
    {
        var passed = Roles
            .IgnoreQueryFilters()
            .Any(r => CurrentUserRoles.Contains(r.Id) && r.Privs.Contains(privilege) && r.UsersArePortalAdmins);

        if (!passed)
        {
            var currentUser = GetCurrentUser();

            if (retry && currentUser is not null)
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted as current user is not portal admin: '{currentUser.Id}'");
                loadedUsers.TryRemove(currentUser.Id, out _);
            }
            else
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted as current user is not portal admin: '{currentUser?.Id}'");
                throw new SecurityException("Access Denied!");
            }
        }
    }

    public void UserHasPrivilegeInBucket(string userId, string privilege, Guid bucketId) =>
        UserHasPrivilegeInBucket(userId, privilege, bucketId, true);

    private void UserHasPrivilegeInBucket(string userId, string privilege, Guid bucketId, bool retry)
    {
        var user = GetAndCacheUser(userId);

        if (user == null)
        {
            Logger.LogWarning($"Privilege '{privilege}' is not granted as user cannot be found '{userId}'");
            throw new SecurityException("Access Denied!");
        }

        var userRoles = user.Roles.Select(u => u.RoleId).ToArray();

        var bucketRoles = BucketRoles
            .IgnoreQueryFilters()
            .Where(br => br.BucketId == bucketId)
            .Select(b => b.RoleId)
            .ToArray();

        var sharedRoles = userRoles.Where(ur => bucketRoles.Contains(ur)).ToArray();

        var passed = Roles
            .IgnoreQueryFilters()
            .Any(r => sharedRoles.Contains(r.Id) && r.Privs.Contains(privilege));

        if (!passed)
        {
            if (retry)
            {
                Logger.LogWarning($"Cached User '{userId}' does not have Privilege '{privilege}' in bucket '{bucketId}', retrying ...");
                loadedUsers.TryRemove(userId, out _);
                UserHasPrivilegeInBucket(userId, privilege, bucketId, false);
            }
            else
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted in bucket '{bucketId}' for user '{userId}'");
                throw new SecurityException("Access Denied!");
            }
        }
    }

    public void UserHasPrivilege(string privilege) =>
        UserHasPrivilege(privilege, true);

    private void UserHasPrivilege(string privilege, bool retry)
    {
        var userRoles = CurrentUserRoles;
        var passed = Roles.Any(r => userRoles.Contains(r.Id) && r.Privs.Contains(privilege));

        if (!passed)
        {
            var currentUser = GetCurrentUser();

            if (retry && currentUser is not null)
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted for cached user: {currentUser.Id}, retrying ...");
                loadedUsers.TryRemove(currentUser.Id, out _);
                UserHasPrivilege(privilege, false);
            }
            else
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted for current user: {currentUser?.Id}");
                throw new SecurityException("Access Denied!");
            }
        }
    }

    public void UserHasPrivilegeInAnyBucket(string userId, string privilege, IEnumerable<Guid> bucketIds) =>
        UserHasPrivilegeInAnyBucket(userId, privilege, bucketIds, true);

    public void UserHasPrivilegeInAnyBucket(string userId, string privilege, IEnumerable<Guid> bucketIds, bool retry)
    {
        var user = GetAndCacheUser(userId);

        if (user == null)
            throw new SecurityException("Access Denied!");

        var userRoles = user.Roles.Select(u => u.RoleId).ToArray();

        var roles = Buckets
            .IgnoreQueryFilters()
            .Where(b => bucketIds.Contains(b.Id))
            .SelectMany(b => b.Roles.Select(r => r.Role));

        var passed = roles.Any(r => userRoles.Contains(r.Id) && r.Privs.Contains(privilege));

        if (!passed)
        {
            if (retry)
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted in ANY bucket within '{string.Join(",", bucketIds.Select(b => b.ToString()))}' for cached user '{userId}', retrying ...");
                loadedUsers.TryRemove(userId, out _);
                UserHasPrivilegeInAnyBucket(userId, privilege, bucketIds, false);
            }

            Logger.LogWarning($"Privilege '{privilege}' is not granted in ANY bucket within '{string.Join(",", bucketIds.Select(b => b.ToString()))}' for user '{userId}'");
            throw new SecurityException("Access Denied!");
        }
    }

    public void UserHasPrivilegeInAllBuckets(string privilege, IEnumerable<Guid> bucketIds) =>
        UserHasPrivilegeInAllBuckets(privilege, bucketIds, true);

    private void UserHasPrivilegeInAllBuckets(string privilege, IEnumerable<Guid> bucketIds, bool retry)
    {
        var userRoles = CurrentUserRoles;

        var buckets = Buckets
            .IgnoreQueryFilters()
            .Where(b => bucketIds.Contains(b.Id))
            .Select(b => new { Bucket = b.Id, Roles = b.Roles.Select(r => r.Role) });

        var passed = buckets.All(b => b.Roles.Any(r => userRoles.Contains(r.Id) && r.Privs.Contains(privilege)));

        if (!passed)
        {
            var currentUser = GetCurrentUser();

            if (retry && currentUser is not null)
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted in ALL buckets '{string.Join(",", bucketIds.Select(b => b.ToString()))}' for cached user '{currentUser.Id}', retrying ...");
                loadedUsers.TryRemove(currentUser.Id, out _);
                UserHasPrivilegeInAllBuckets(privilege, bucketIds, false);
            }
            else
            {
                Logger.LogWarning($"Privilege '{privilege}' is not granted in ALL buckets '{string.Join(",", bucketIds.Select(b => b.ToString()))}' for user '{currentUser?.Id}'");
                throw new SecurityException("Access Denied!");
            }
        }
    }
}