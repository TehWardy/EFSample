using B2B.Data.Brokers.Storages.Auditing.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing
{
    public class AuditItemLevelBroker : IAuditItemLevelBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public AuditItemLevelBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public IQueryable<AuditItemLevel> GetAllAuditItemLevels()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.AuditItemLevels;
        }
    }
}