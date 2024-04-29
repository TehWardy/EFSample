using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IInvoiceReferenceBroker
    {
        ValueTask<InvoiceReference> AddInvoiceReferenceAsync(InvoiceReference invoiceReference);
        ValueTask DeleteInvoiceReferenceAsync(InvoiceReference invoiceReference);
        IQueryable<InvoiceReference> GetAllInvoiceReferences(bool ignoreFilters = false);
        ValueTask<InvoiceReference> UpdateInvoiceReferenceAsync(InvoiceReference invoiceReference);
    }
}