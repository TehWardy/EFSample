using B2B.Objects.Entities.Logging;

namespace B2B.Data.Brokers.Storages.Auditing.Interfaces;

public interface IInvoiceAuditItemBroker
{
    IQueryable<InvoiceAuditItem> GetAllInvoiceAuditItems();
    ValueTask<InvoiceAuditItem> AddInvoiceAuditItemAsync(InvoiceAuditItem invoiceAuditItem);
    ValueTask<IEnumerable<InvoiceAuditItem>> AddAllInvoiceAuditItemsAsync(IEnumerable<InvoiceAuditItem> items);
    ValueTask DeleteInvoiceAuditItemAsync(InvoiceAuditItem invoiceAuditItem);
}