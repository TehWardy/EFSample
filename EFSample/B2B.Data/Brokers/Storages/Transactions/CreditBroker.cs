using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Transactions;

public class CreditBroker : ICreditBroker
{
    private readonly IB2BDbContextFactory contextFactory;

    public CreditBroker(IB2BDbContextFactory contextFactory) =>
        this.contextFactory = contextFactory;

    public async ValueTask<Credit> AddCreditAsync(Credit credit)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = await context.Credits.AddAsync(credit);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<Credit> UpdateCreditAsync(Credit credit)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Credits.Update(credit);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteCreditAsync(Credit credit)
    {
        using var context = contextFactory.CreateDbContext();

        var entityEntry = context.Credits.Remove(credit);
        await context.SaveChangesAsync();
    }

    public IQueryable<Credit> GetAllCredits(bool ignoreFilters = false, bool loadChildren = false)
    {
        var context = contextFactory.CreateDbContext();

        var result = ignoreFilters
            ? context.Credits.IgnoreQueryFilters()
            : context.Credits;

        if (loadChildren)
            result = result
                .Include(c => c.Companies)
                .Include(c => c.Lines)
                .Include(c => c.References)
                .Include(c => c.Buckets);

        return result;
    }

    public async ValueTask DeleteAllCreditsForSystem(string sourceSystemId)
    {
        using var context = contextFactory.CreateDbContext();
        await context.DeleteAllCreditsForSystem(sourceSystemId);
    }

    public IEnumerable<Guid> ComputeBuckets(Guid rootBucket, string[] buyerRefs, string[] supplierRefs, string[] funderRefs)
    {
        using var context = contextFactory.CreateDbContext();
        return context.ComputeBuckets(rootBucket, buyerRefs, supplierRefs, funderRefs);
    }

    public bool AnyBucketFundingType(IEnumerable<Guid> bucketIds)
    {
        using var context = contextFactory.CreateDbContext();

        return context.Buckets
            .Any(b => bucketIds.Contains(b.Id) && b.Key == "FundingType");
    }
}