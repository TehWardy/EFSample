using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing.Interfaces;

public interface ICreditAuditItemBroker
{
    IQueryable<CreditAuditItem> GetAllCreditAuditItems(bool ignoreFilters = false);
    ValueTask<CreditAuditItem> AddCreditAuditItemAsync(CreditAuditItem creditAuditItem);
    ValueTask<IEnumerable<CreditAuditItem>> AddAllCreditAuditItemsAsync(IEnumerable<CreditAuditItem> creditAuditItem);
    ValueTask DeleteCreditAuditItemAsync(CreditAuditItem creditAuditItem);
}