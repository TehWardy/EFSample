using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Data.EF;

public partial class B2BDbContext
{
    // Masterdata primary entities
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Bucket> Buckets { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<B2BSystem> Systems { get; set; }

    // Masterdata secondary entities
    public DbSet<CompanyReference> CompanyReferences { get; set; }
    public DbSet<BucketCompany> BucketCompanies { get; set; }
    public DbSet<BucketCredit> BucketCredits { get; set; }
    public DbSet<BucketInvoice> BucketInvoices { get; set; }
    public DbSet<BucketOffer> BucketOffers { get; set; }
    public DbSet<BucketPurchaseOrder> BucketPurchaseOrders { get; set; }
    public DbSet<BucketRemittanceAdvice> BucketRemittanceAdvices { get; set; }
    public DbSet<BucketActiveTransaction> BucketActiveTransactions { get; set; }
    public DbSet<BucketSystem> BucketSystems { get; set; }
    public DbSet<BucketRole> BucketRoles { get; set; }

    private static readonly System.Timers.Timer treeCacheTimer = new();
    private static readonly ConcurrentDictionary<Guid, (Guid id, string key)[]> treeCache = new();

    private void ApplyMasterdataFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BucketRole>().HasQueryFilter(i => i.Role != null);
        modelBuilder.Entity<Bucket>().HasQueryFilter(i => i.Roles.Count != 0);
        modelBuilder.Entity<BucketCompany>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<BucketUser>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<BucketPayee>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<Company>().HasQueryFilter(i => UserIsPortalAdmin || i.Buckets.Count != 0);
        modelBuilder.Entity<CompanyReference>().HasQueryFilter(i => i.System != null);
        modelBuilder.Entity<CompanyPayee>().HasQueryFilter(i => i.Company != null);
        modelBuilder.Entity<BucketSystem>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<B2BSystem>().HasQueryFilter(i => UserIsPortalAdmin || i.IsPublic || i.Buckets.Count != 0);
    }

    private static void SeedMasterdata(ModelBuilder modelBuilder)
    {
        SeedCountries(modelBuilder);
        SeedCurrencies(modelBuilder);
    }

    public Guid[] ComputeBucketsFromLineRefs(string[] invoiceRefs, string[] creditRefs)
    {
        Guid[] invoiceBucketIds = BucketInvoices
            .IgnoreQueryFilters()
            .Where(bi => bi.Invoice.References.Any(ir => invoiceRefs.Contains(ir.Id)))
            .Select(bi => bi.BucketId)
            .Distinct()
            .ToArray();

        Guid[] creditBucketIds = BucketCredits
            .IgnoreQueryFilters()
            .Where(bc => bc.Credit.References.Any(cr => creditRefs.Contains(cr.Id)))
            .Select(bc => bc.BucketId)
            .Distinct()
            .ToArray();

        return invoiceBucketIds.Union(creditBucketIds).Distinct().ToArray();
    }

    public IEnumerable<(string companyRef, string perspective)> GetCompaniesByLineRefs(
        string[] invoiceRefs,
        string[] creditRefs,
        bool computeFunder = false)
    {
        IEnumerable<(string companyRef, string perspective)> invoiceCompanyInfo = InvoiceCompanies
            .IgnoreQueryFilters()
            .Where(ic => ic.Invoice.References.Any(ir => invoiceRefs.Contains(ir.Id)))
            .ToArray()
            .Select(i => (i.CompanyReferenceId, i.Perspective))
            .ToArray();

        IEnumerable<(string companyRef, string perspective)> creditCompanyInfo = CreditCompanies
            .IgnoreQueryFilters()
            .Where(ic => ic.Credit.References.Any(cr => creditRefs.Contains(cr.Id)))
            .ToArray()
            .Select(i => (i.CompanyReferenceId, i.Perspective))
            .ToArray();

        var results = invoiceCompanyInfo.Union(creditCompanyInfo)
            .GroupBy(i => new { i.companyRef, i.perspective })
            .Select(g => g.First())
            .ToList();

        if (computeFunder)
        {
            var sourceSystem = InvoiceReferences
                .IgnoreQueryFilters()
                .Where(r => r.Id == invoiceRefs.First())
                .Select(r => r.Invoice.SourceSystemId)
                .First();

            var funderBucketIds = Invoices
                .IgnoreQueryFilters()
                .Where(i => i.References.Any(ir => invoiceRefs.Contains(ir.Id)))
                .SelectMany(i => i.Buckets.Where(b => b.Bucket.Key == "FundingType").Select(b => b.Bucket.Parent))
                .Select(fb => fb.Id)
                .ToArray();

            if (funderBucketIds.Count() == 0)
                return results;

            var funderReference = BucketCompanies
                .IgnoreQueryFilters()
                .Where(bc => funderBucketIds.Contains(bc.BucketId))
                .SelectMany(bc => bc.Company.References.Where(cr => cr.SystemId == sourceSystem))
                .FirstOrDefault();

            if (funderReference is not null)
                results.Add((funderReference.Id, "Funder"));
        }

        return results;
    }

    public IEnumerable<Guid> ComputeBuckets(Guid rootBucket, string[] buyerRefs, string[] supplierRefs, string[] funderRefs) =>
        ComputeBucketsForPerspective(rootBucket, "Debtor", buyerRefs)
            .Union(ComputeBucketsForPerspective(rootBucket, "Creditor", supplierRefs))
            .Union(ComputeBucketsForPerspective(rootBucket, "Funder", funderRefs))
            .Union(ComputeBucketsForPerspective(rootBucket, "FundingType", supplierRefs));

    private Guid[] ComputeBucketsForPerspective(Guid rootBucket, string perspective, string[] refs)
    {
        var referencedBuckets = CompanyReferences
            .IgnoreQueryFilters()
            .Where(r => refs.Contains(r.Id))
            .SelectMany(r => r.Company.Buckets.Select(b => b.Bucket.Id))
            .ToArray();

        (Guid id, string key)[] scopedBuckets = GetBucketsInTree(rootBucket);

        return referencedBuckets
            .Where(rb => scopedBuckets.Any(sb => sb.key == perspective && sb.id == rb))
            .ToArray();
    }

    private (Guid id, string key)[] GetBucketsInTree(Guid rootBucket)
    {
        if (!treeCache.TryGetValue(rootBucket, out (Guid id, string key)[] tree))
        {
            string startingPath = Buckets.First(b => b.Id == rootBucket).Path;

            tree = Buckets
                .IgnoreQueryFilters()
                .Where(b => b.Path.StartsWith(startingPath))
                .Select(b => new { b.Id, b.Key })
                .AsEnumerable()
                .Select(b => (b.Id, b.Key))
                .ToArray();

            treeCache[rootBucket] = tree;
        }

        return tree;
    }
}