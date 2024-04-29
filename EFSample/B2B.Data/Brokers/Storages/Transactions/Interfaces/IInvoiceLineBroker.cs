using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IInvoiceLineBroker
    {
        ValueTask<InvoiceLine> AddInvoiceLineAsync(InvoiceLine invoiceLine);
        ValueTask DeleteInvoiceLineAsync(InvoiceLine invoiceLine);
        IQueryable<InvoiceLine> GetAllInvoiceLines(bool ignoreFilters = false);
        ValueTask<InvoiceLine> UpdateInvoiceLineAsync(InvoiceLine invoiceLine);
    }
}