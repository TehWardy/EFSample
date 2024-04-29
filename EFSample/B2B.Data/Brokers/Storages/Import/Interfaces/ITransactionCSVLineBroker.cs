using B2B.Objects.Entities.Import;

namespace B2B.Data.Brokers.Storages.Import.Interfaces
{
    public interface ITransactionCSVLineBroker
    {
        ValueTask<TransactionCSVLine> AddTransactionCSVLineAsync(TransactionCSVLine transactionCSVLine);
        ValueTask<IEnumerable<TransactionCSVLine>> AddAllTransactionCSVLinesAsync(IEnumerable<TransactionCSVLine> lines);
        ValueTask DeleteTransactionCSVLineAsync(TransactionCSVLine transactionCSVLine);
        IQueryable<TransactionCSVLine> GetAllTransactionCSVLines();
        ValueTask<TransactionCSVLine> UpdateTransactionCSVLineAsync(TransactionCSVLine transactionCSVLine);
    }
}