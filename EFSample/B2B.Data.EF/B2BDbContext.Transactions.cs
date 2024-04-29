using B2B.Objects.Entities;
using B2B.Objects.Entities.Logging;
using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF;

public partial class B2BDbContext
{

    // Transactions primary entities
    public DbSet<ActiveTransaction> ActiveTransactions { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Credit> Credits { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    // Transactions secondary entities
    public DbSet<InvoiceType> InvoiceTypes { get; set; }
    public DbSet<CreditType> CreditTypes { get; set; }

    // Line Items
    public DbSet<InvoiceLine> InvoiceLines { get; set; }
    public DbSet<CreditLine> CreditLines { get; set; }
    public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }

    // References
    public DbSet<InvoiceReference> InvoiceReferences { get; set; }
    public DbSet<CreditReference> CreditReferences { get; set; }
    public DbSet<PurchaseOrderReference> PurchaseOrderReferences { get; set; }

    // Companies
    public DbSet<InvoiceCompany> InvoiceCompanies { get; set; }
    public DbSet<CreditCompany> CreditCompanies { get; set; }
    public DbSet<PurchaseOrderCompany> PurchaseOrderCompanies { get; set; }

    private static void ApplyTransactionFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveTransaction>().HasQueryFilter(i => i.Buckets.Any());
        modelBuilder.Entity<BucketActiveTransaction>().HasQueryFilter(i => i.Bucket != null);

        modelBuilder.Entity<BucketInvoice>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<Invoice>().HasQueryFilter(i => i.Buckets.Any());
        modelBuilder.Entity<InvoiceLine>().HasQueryFilter(i => i.Invoice != null);
        modelBuilder.Entity<InvoiceCompany>().HasQueryFilter(i => i.Invoice != null);
        modelBuilder.Entity<InvoiceReference>().HasQueryFilter(i => i.Invoice != null);
        modelBuilder.Entity<InvoiceAuditItem>().HasQueryFilter(i => i.Invoice != null);

        modelBuilder.Entity<BucketCredit>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<Credit>().HasQueryFilter(i => i.Buckets.Any());
        modelBuilder.Entity<CreditLine>().HasQueryFilter(i => i.Credit != null);
        modelBuilder.Entity<CreditCompany>().HasQueryFilter(i => i.Credit != null);
        modelBuilder.Entity<CreditReference>().HasQueryFilter(i => i.Credit != null);
        modelBuilder.Entity<CreditAuditItem>().HasQueryFilter(i => i.Credit != null);

        modelBuilder.Entity<BucketPurchaseOrder>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<PurchaseOrder>().HasQueryFilter(i => i.Buckets.Any());
        modelBuilder.Entity<PurchaseOrderLine>().HasQueryFilter(i => i.PurchaseOrder != null);
        modelBuilder.Entity<PurchaseOrderCompany>().HasQueryFilter(i => i.PurchaseOrder != null);
        modelBuilder.Entity<PurchaseOrderReference>().HasQueryFilter(i => i.PurchaseOrder != null);
        modelBuilder.Entity<PurchaseOrderAuditItem>().HasQueryFilter(i => i.PurchaseOrder != null);
    }

    private static void SeedTransactions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvoiceType>().HasData(new[] {
            new InvoiceType { Id = 1,  Name = "Sales Invoice" },
            new InvoiceType { Id = 2,  Name = "Copy Invoice" },
            new InvoiceType { Id = 3,  Name = "Replacement" },
            new InvoiceType { Id = 4,  Name = "Self Billing Invoice" },
            new InvoiceType { Id = 5,  Name = "Pro Forma Inv" }
        });

        modelBuilder.Entity<CreditType>().HasData(new[] {
            new CreditType { Id = 1,  Name = "Credit Note" },
            new CreditType { Id = 2,  Name = "Replacement" },
            new CreditType { Id = 3,  Name = "Debit Note" },
            new CreditType { Id = 4,  Name = "Self Billing Credit" }
        });
    }

    public async ValueTask DeleteAllCreditsForSystem(string sourceSystemId)
    {
        Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        _ = await Database.ExecuteSqlRawAsync(@"
DECLARE @Credits as TABLE(CreditId uniqueidentifier);

INSERT INTO @Credits
	SELECT Id FROM [Transactions].[Credits] c WHERE EXISTS(SELECT * FROM [Transactions].[CreditReferences] cr WHERE cr.CreditId=c.Id AND cr.SystemId=@p0)

-- Delete buckets.
DELETE FROM [Masterdata].[BucketCredits] WHERE CreditId IN (SELECT CreditId FROM @Credits)

-- Delete audits.
DELETE FROM [Logging].[CreditAuditItems] WHERE CreditId IN (SELECT CreditId FROM @Credits)

-- Delete companies.
DELETE FROM [Transactions].[CreditCompanies] WHERE CreditId IN (SELECT CreditId FROM @Credits)

-- Delete lines.
DELETE FROM [Transactions].[CreditLines] WHERE CreditId IN (SELECT CreditId FROM @Credits)

-- Delete references.
DELETE FROM [Transactions].[CreditReferences] WHERE CreditId IN (SELECT CreditId FROM @Credits)

-- Delete credits.
DELETE FROM [Transactions].[Credits] WHERE Id IN (SELECT CreditId FROM @Credits)
", sourceSystemId);
    }

    public async ValueTask DeleteAllInvoicesForSystem(string sourceSystemId)
    {
        Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        _ = await Database.ExecuteSqlRawAsync(@"
DECLARE @Invoices as TABLE(InvoiceId uniqueidentifier);

INSERT INTO @Invoices
	SELECT Id FROM [Transactions].[Invoices] i WHERE EXISTS(SELECT * FROM [Transactions].[InvoiceReferences] ir WHERE ir.InvoiceId=i.Id AND ir.SystemId=@p0)

-- Delete buckets.
DELETE FROM [Masterdata].[BucketInvoices] WHERE InvoiceId IN (SELECT InvoiceId FROM @Invoices)

-- Delete audits.
DELETE FROM [Logging].[InvoiceAuditItems] WHERE InvoiceId IN (SELECT InvoiceId FROM @Invoices)

-- Delete companies.
DELETE FROM [Transactions].[InvoiceCompanies] WHERE InvoiceId IN (SELECT InvoiceId FROM @Invoices)

-- Delete lines.
DELETE FROM [Transactions].[InvoiceLines] WHERE InvoiceId IN (SELECT InvoiceId FROM @Invoices)

-- Delete references.
DELETE FROM [Transactions].[InvoiceReferences] WHERE InvoiceId IN (SELECT InvoiceId FROM @Invoices)

-- Delete invoices.
DELETE FROM [Transactions].[Invoices] WHERE Id IN (SELECT InvoiceId FROM @Invoices)
", sourceSystemId);
    }

    public async ValueTask DeleteAllActiveTransactionsForSystem(string sourceSystemId)
    {
        await BucketActiveTransactions
            .IgnoreQueryFilters()
            .Where(bat => bat.ActiveTransaction.SourceSystemId == sourceSystemId)
            .ExecuteDeleteAsync();

        await ActiveTransactions
            .IgnoreQueryFilters()
            .Where(at => at.SourceSystemId == sourceSystemId)
            .ExecuteDeleteAsync();
    }
}