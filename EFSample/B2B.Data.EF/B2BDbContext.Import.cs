using B2B.Objects.Entities.Import;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF;

public partial class B2BDbContext
{
    // Transactions primary entities
    public DbSet<CompanyCSVLine> CompanyCSVLines { get; set; }
    public DbSet<TransactionCSVLine> TransactionCSVLines { get; set; }

    private static void ApplyImportFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyCSVLine>().HasQueryFilter(i => i.RootBucket != null);
        modelBuilder.Entity<TransactionCSVLine>().HasQueryFilter(i => i.RootBucket != null);
    }
}