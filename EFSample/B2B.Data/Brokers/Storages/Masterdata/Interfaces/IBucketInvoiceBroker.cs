using B2B.Objects.Entities.Masterdata;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface IBucketInvoiceBroker
    {
        ValueTask<BucketInvoice> AddBucketInvoiceAsync(BucketInvoice bucketInvoice);
        ValueTask<BucketInvoice> UpdateBucketInvoiceAsync(BucketInvoice bucketInvoice);
        ValueTask DeleteBucketInvoiceAsync(BucketInvoice bucketInvoice);
        IQueryable<BucketInvoice> GetAllBucketInvoices(bool ignoreFilters = false);
    }
}