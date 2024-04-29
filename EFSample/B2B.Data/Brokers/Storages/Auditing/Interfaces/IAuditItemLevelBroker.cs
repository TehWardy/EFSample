using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing.Interfaces
{
    public interface IAuditItemLevelBroker
    {
        IQueryable<AuditItemLevel> GetAllAuditItemLevels();
    }
}