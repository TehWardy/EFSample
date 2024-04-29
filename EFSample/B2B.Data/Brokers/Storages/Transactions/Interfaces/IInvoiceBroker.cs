using B2B.Objects.Entities.Transactions;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces;

public interface IInvoiceBroker
{
    IQueryable<Invoice> GetAllInvoices(bool ignoreFilters = false, bool loadChildren = false);
    IEnumerable<Guid> ComputeBuckets(Guid rootBucket, string[] buyerRefs, string[] supplierRefs, string[] funderRefs);

    ValueTask<Invoice> AddInvoiceAsync(Invoice invoice);
    ValueTask DeleteInvoiceAsync(Invoice invoice);
    ValueTask<Invoice> UpdateInvoiceAsync(Invoice invoice);
    ValueTask DeleteAllInvoicesForSystem(string sourceSystemId);

    bool AnyBucketFundingType(IEnumerable<Guid> bucketIds);
}