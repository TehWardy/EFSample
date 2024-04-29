using B2B.Data.Brokers.Storages.Security.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Security;

namespace B2B.Data.Brokers.Storages.Security
{
    public class B2BAuthorizationBroker : IB2BAuthorizationBroker
    {
        private readonly IB2BDbContextFactory contextFactory;

        public B2BAuthorizationBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public IEnumerable<B2BPrivilege> GetAllPrivileges() =>
            B2BDbContext.GetAllPrivileges();

        public B2BUser GetCurrentUser()
        {
            var db = contextFactory.CreateDbContext();
            return db.GetCurrentUser();
        }

        public void UserHasPrivilege(string privilege)
        {
            var db = contextFactory.CreateDbContext();
            db.UserHasPrivilege(privilege);
        }

        public void UserHasPrivilegeInBucket(string userId, string privilege, Guid bucketId)
        {
            var db = contextFactory.CreateDbContext();
            db.UserHasPrivilegeInBucket(userId, privilege, bucketId);
        }

        public void UserIsPortalAdminWithPrivilege(string privilege)
        {
            var db = contextFactory.CreateDbContext();
            db.UserIsPortalAdminWithPrivilege(privilege);
        }

        public void UserHasPrivilegeInAllBuckets(string privilege, IEnumerable<Guid> bucketIds)
        {
            var db = contextFactory.CreateDbContext();
            db.UserHasPrivilegeInAllBuckets(privilege, bucketIds);
        }

        public void UserHasPrivilegeInAnyBucket(string privilege, IEnumerable<Guid> bucketIds)
        {
            var db = contextFactory.CreateDbContext();
            db.UserHasPrivilegeInAnyBucket(GetCurrentUser().Id, privilege, bucketIds);
        }

        public void UserHasPrivilegeInAnyBucket(string userId, string privilege, IEnumerable<Guid> bucketIds)
        {
            var db = contextFactory.CreateDbContext();
            db.UserHasPrivilegeInAnyBucket(userId, privilege, bucketIds);
        }
    }
}