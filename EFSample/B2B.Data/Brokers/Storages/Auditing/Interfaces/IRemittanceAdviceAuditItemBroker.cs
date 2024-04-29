using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing.Interfaces;

public interface IRemittanceAdviceAuditItemBroker
{
    IQueryable<RemittanceAdviceAuditItem> GetAllRemittanceAdviceAuditItems(bool ignoreFilters = false);
    ValueTask<RemittanceAdviceAuditItem> AddRemittanceAdviceAuditItemAsync(RemittanceAdviceAuditItem remittanceAdviceAuditItem);
    ValueTask<IEnumerable<RemittanceAdviceAuditItem>> AddAllRemittanceAdviceAuditItemsAsync(IEnumerable<RemittanceAdviceAuditItem> items);
    ValueTask DeleteRemittanceAdviceAuditItemAsync(RemittanceAdviceAuditItem remittanceAdviceAuditItem);
}