using B2B.Objects.Entities.Logging;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF;

public partial class B2BDbContext
{
    // Auditing primary entities
    public DbSet<InvoiceAuditItem> InvoiceAuditItems { get; set; }
    public DbSet<CreditAuditItem> CreditAuditItems { get; set; }
    public DbSet<PurchaseOrderAuditItem> PurchaseOrderAuditItems { get; set; }
    public DbSet<RemittanceAdviceAuditItem> RemittanceAdviceAuditItems { get; set; }
    public DbSet<OfferAuditItem> OfferAuditItems { get; set; }

    // we should probably migrate these out as we don't use them
    //public DbSet<LogEntry> LogEntries { get; set; }
    //public DbSet<LogEntryDataItem> LogEntryDataItems { get; set; }

    // Auditing secondary entities
    public DbSet<AuditItemLevel> AuditItemLevels { get; set; }

    private static void SeedAuditing(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditItemLevel>().HasData(new[] {
            new AuditItemLevel { Id = 1, Name = "Fatal" },
            new AuditItemLevel { Id = 2, Name = "Error" },
            new AuditItemLevel { Id = 3, Name = "Warning" },
            new AuditItemLevel { Id = 4, Name = "Success" },
            new AuditItemLevel { Id = 5, Name = "Info" },
            new AuditItemLevel { Id = 6, Name = "Debug" }
        });
    }
}