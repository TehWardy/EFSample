using B2B.Data.Brokers.Storages.Funding.Interfaces;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Funding.Offer;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.Brokers.Storages.Funding;

public class OfferBroker(
    IB2BDbContextFactory contextFactory) : IOfferBroker
{
    public IQueryable<Offer> GetAllOffers(bool ignoreFilters = false, bool loadChildren = false)
    {
        var context = contextFactory.CreateDbContext();

        var result = ignoreFilters
            ? context.Offers.IgnoreQueryFilters()
            : context.Offers;

        if (loadChildren)
            result = result
                .Include(o => o.Buckets)
                .Include(o => o.Companies)
                .Include(o => o.Lines)
                .Include(o => o.References);

        return result;
    }

    public async ValueTask<Offer> AddOfferAsync(Offer offer)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = await context.Offers.AddAsync(offer);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<IEnumerable<Offer>> AddAllOffersAsync(IEnumerable<Offer> offers)
    {
        using var context = contextFactory.CreateDbContext();

        await context.Offers.AddRangeAsync(offers);
        await context.SaveChangesAsync();

        return offers;
    }

    public async ValueTask<Offer> UpdateOfferAsync(Offer offer)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = context.Offers.Update(offer);
        await context.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask DeleteOfferAsync(Offer offer)
    {
        using var context = contextFactory.CreateDbContext();
        var entityEntry = context.Offers.Remove(offer);
        await context.SaveChangesAsync();
    }

    public async ValueTask DeleteAllOffersForSystem(string sourceSystemId)
    {
        using var context = contextFactory.CreateDbContext();
        await context.DeleteAllOffersForSystem(sourceSystemId);
    }

    public async ValueTask DeleteAllOffersAsync(IEnumerable<Offer> offers)
    {
        using var context = contextFactory.CreateDbContext();
        context.RemoveRange(offers);
        await context.SaveChangesAsync();
    }

    public IEnumerable<Guid> ComputeBuckets(string[] invoiceRefs, string[] creditRefs)
    {
        using var context = contextFactory.CreateDbContext();
        return context.ComputeBucketsFromLineRefs(invoiceRefs, creditRefs);
    }

    public IEnumerable<(string companyReferenceId, string perspective)> GetCompanies(string[] invoiceRefs, string[] creditRefs)
    {
        using var context = contextFactory.CreateDbContext();
        return context.GetCompaniesByLineRefs(invoiceRefs, creditRefs, computeFunder: true);
    }
}