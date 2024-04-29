using B2B.Objects.Entities.Payments;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IRemittanceAdviceLineBroker
    {
        ValueTask<RemittanceAdviceLine> AddRemittanceAdviceLineAsync(RemittanceAdviceLine remittanceAdviceLine);
        ValueTask DeleteRemittanceAdviceLineAsync(RemittanceAdviceLine remittanceAdviceLine);
        IQueryable<RemittanceAdviceLine> GetAllRemittanceAdviceLines(bool ignoreFilters = false);
        ValueTask<RemittanceAdviceLine> UpdateRemittanceAdviceLineAsync(RemittanceAdviceLine remittanceAdviceLine);

        bool InvoiceReferenceExists(string invoiceReference);
        bool CreditReferenceExists(string creditReference);
        bool OfferReferenceExists(string offerReference);
    }
}