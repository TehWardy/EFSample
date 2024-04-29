using B2B.Objects.Entities.Transactions;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces;

public interface IActiveTransactionBroker
{
    IQueryable<ActiveTransaction> GetAllActiveTransactions(bool ignoreFilters = false);
    IQueryable<ActiveTransaction> GetAllActiveTransactionsForFunding(IEnumerable<string> transactionRefs);
    ValueTask<ActiveTransaction> AddActiveTransactionAsync(ActiveTransaction ActiveTransaction);
    ValueTask DeleteActiveTransactionAsync(ActiveTransaction ActiveTransaction);
    ValueTask<ActiveTransaction> UpdateActiveTransactionAsync(ActiveTransaction ActiveTransaction);
    ValueTask DeleteAllActiveTransactionsForSystem(string sourceSystemId);
}