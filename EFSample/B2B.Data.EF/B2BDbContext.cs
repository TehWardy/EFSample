using B2B.Data.EF.Interfaces;
using B2B.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace B2B.Data.EF;

public partial class B2BDbContext : DbContext
{
    public IB2BAuthInfo AuthInfo { get; set; }

    public IB2BModelBuildProvider ModelBuildProvider { get; set; }
    public ILogger Logger { get; set; }

    static B2BDbContext()
    {
        treeCacheTimer.Interval = 900000;

        treeCacheTimer.Elapsed +=
            (object sender, System.Timers.ElapsedEventArgs e) => treeCache.Clear();

        treeCacheTimer.Start();
    }

    public B2BDbContext(DbContextOptions<B2BDbContext> options) : base(options) { }

    public void Migrate() =>
        ModelBuildProvider.MigrateDatabase(Database);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelBuildProvider.Create(modelBuilder);
        ApplyFilters(modelBuilder);
        SeedDatabase(modelBuilder);
    }

    private void ApplyFilters(ModelBuilder modelBuilder)
    {
        ApplySecurityFilters(modelBuilder);
        ApplyMasterdataFilters(modelBuilder);
        ApplyTransactionFilters(modelBuilder);
        ApplyPaymentFilters(modelBuilder);
        ApplyFinancingFilters(modelBuilder);
        ApplyImportFilters(modelBuilder);
        ApplyBankingFilters(modelBuilder);
    }

    private void SeedDatabase(ModelBuilder modelBuilder)
    {
        SeedMasterdata(modelBuilder);
        SeedAuditing(modelBuilder);
        SeedPayments(modelBuilder);
        SeedTransactions(modelBuilder);
    }
}