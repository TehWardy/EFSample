using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Payments;

namespace B2B.Data.Brokers.Storages.Transactions;

public class RemittanceAdviceBroker : IRemittanceAdviceBroker
{
    private readonly IB2BDbContextFactory contextFactory;
    private B2BDbContext readContext;

    public RemittanceAdviceBroker(IB2BDbContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async ValueTask<RemittanceAdvice> AddRemittanceAdviceAsync(RemittanceAdvice remittanceAdvice)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = await context.RemittanceAdvices.AddAsync(remittanceAdvice);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<RemittanceAdvice> UpdateRemittanceAdviceAsync(RemittanceAdvice remittanceAdvice)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = context.RemittanceAdvices.Update(remittanceAdvice);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteRemittanceAdviceAsync(RemittanceAdvice remittanceAdvice)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = context.RemittanceAdvices.Remove(new RemittanceAdvice() { Id = remittanceAdvice.Id });
        await context.SaveChangesAsync();
    }

    public IQueryable<RemittanceAdvice> GetAllRemittanceAdvices()
    {
        readContext ??= contextFactory.CreateDbContext();
        return readContext.RemittanceAdvices;
    }

    public async ValueTask DeleteAllRemittanceAdviceForSystem(string sourceSystemId)
    {
        using var context = contextFactory.CreateDbContext();
        await context.DeleteAllRemittanceAdviceForSystem(sourceSystemId);
    }

    public IEnumerable<Guid> ComputeBuckets(string[] invoiceRefs, string[] creditRefs)
    {
        readContext ??= contextFactory.CreateDbContext();
        return readContext.ComputeBucketsFromLineRefs(invoiceRefs, creditRefs);
    }

    public IEnumerable<(string companyReferenceId, string perspective)> GetCompanies(
        string[] invoiceRefs,
        string[] creditRefs)
    {
        readContext ??= contextFactory.CreateDbContext();
        return readContext.GetCompaniesByLineRefs(invoiceRefs, creditRefs);
    }
}