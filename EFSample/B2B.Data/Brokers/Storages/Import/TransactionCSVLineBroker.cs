using B2B.Data.Brokers.Storages.Import.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Import;

namespace B2B.Data.Brokers.Storages.Import
{
    public class TransactionCSVLineBroker : ITransactionCSVLineBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public TransactionCSVLineBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<TransactionCSVLine> AddTransactionCSVLineAsync(TransactionCSVLine transactionCSVLine)
        {
            using var context = contextFactory.CreateDbContext();

            var entityEntry = await context.TransactionCSVLines.AddAsync(transactionCSVLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<IEnumerable<TransactionCSVLine>> AddAllTransactionCSVLinesAsync(
            IEnumerable<TransactionCSVLine> lines)
        {
            using var context = contextFactory.CreateDbContext();

            await context.TransactionCSVLines.AddRangeAsync(lines);
            await context.SaveChangesAsync();

            return lines;
        }

        public async ValueTask<TransactionCSVLine> UpdateTransactionCSVLineAsync(TransactionCSVLine transactionCSVLine)
        {
            using var context = contextFactory.CreateDbContext();

            var entityEntry = context.TransactionCSVLines.Update(transactionCSVLine);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteTransactionCSVLineAsync(TransactionCSVLine transactionCSVLine)
        {
            using var context = contextFactory.CreateDbContext();

            var entityEntry = context.TransactionCSVLines.Remove(transactionCSVLine);
            await context.SaveChangesAsync();
        }

        public IQueryable<TransactionCSVLine> GetAllTransactionCSVLines()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.TransactionCSVLines;
        }
    }
}