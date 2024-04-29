using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IInvoiceCompanyBroker
    {
        ValueTask<InvoiceCompany> AddInvoiceCompanyAsync(InvoiceCompany invoiceCompany);
        ValueTask DeleteInvoiceCompanyAsync(InvoiceCompany invoiceCompany);
        IQueryable<InvoiceCompany> GetAllInvoiceCompanies(bool ignoreFilters = false);
        ValueTask<InvoiceCompany> UpdateInvoiceCompanyAsync(InvoiceCompany invoiceCompany);
    }
}