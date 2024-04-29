using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions;

public class ActiveTransactionBroker : IActiveTransactionBroker
{
    private readonly IB2BDbContextFactory contextFactory;

    public ActiveTransactionBroker(IB2BDbContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public IQueryable<ActiveTransaction> GetAllActiveTransactions(bool ignoreFilters = false)
    {
        var context = contextFactory.CreateDbContext();

        return ignoreFilters
            ? context.ActiveTransactions.IgnoreQueryFilters()
            : context.ActiveTransactions;
    }

    public IQueryable<ActiveTransaction> GetAllActiveTransactionsForFunding(IEnumerable<string> transactionReferences)
    {
        var context = contextFactory.CreateDbContext();

        return context.ActiveTransactions
            .Where(at => transactionReferences.Contains(at.TransactionType + "|" + at.SourceSystemId + "|" + at.TransactionReference))
            .Include(at => at.Buckets)
                .ThenInclude(b => b.Bucket)
                    .ThenInclude(b => b.FundingDetails);
    }

    public async ValueTask<ActiveTransaction> AddActiveTransactionAsync(ActiveTransaction activeTransaction)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.ActiveTransactions.AddAsync(activeTransaction);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<ActiveTransaction> UpdateActiveTransactionAsync(ActiveTransaction activeTransaction)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.ActiveTransactions.Update(activeTransaction);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteActiveTransactionAsync(ActiveTransaction activeTransaction)
    {
        using var context = contextFactory.CreateDbContext();

        context.ActiveTransactions.Remove(activeTransaction);
        await context.SaveChangesAsync();
    }

    public async ValueTask DeleteAllActiveTransactionsForSystem(string sourceSystemId)
    {
        using var context = contextFactory.CreateDbContext();
        await context.DeleteAllActiveTransactionsForSystem(sourceSystemId);
    }
}