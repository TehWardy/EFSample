using B2B.Objects.Entities.Security;

namespace B2B.Data.Brokers.Storages.Security.Interfaces
{
    public interface IB2BAuthorizationBroker
    {
        B2BUser GetCurrentUser();

        IEnumerable<B2BPrivilege> GetAllPrivileges();

        void UserHasPrivilege(string privilege);

        void UserHasPrivilegeInBucket(string userId, string privilege, Guid bucketId);

        void UserIsPortalAdminWithPrivilege(string privilege);

        void UserHasPrivilegeInAnyBucket(string privilege, IEnumerable<Guid> bucketIds);
        void UserHasPrivilegeInAnyBucket(string userId, string privilege, IEnumerable<Guid> bucketIds);

        void UserHasPrivilegeInAllBuckets(string privilege, IEnumerable<Guid> bucketIds);
    }
}