using B2B.Objects.Entities.Logging;
using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Payments;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF;

public partial class B2BDbContext
{
    // Financing primary entities
    public DbSet<RemittanceAdvice> RemittanceAdvices { get; set; }

    // Financing secondary entities
    public DbSet<RemittanceAdviceLine> RemittanceAdviceLines { get; set; }
    public DbSet<RemittanceAdviceReference> RemittanceAdviceReferences { get; set; }
    public DbSet<RemittanceAdviceCompany> RemittanceAdviceCompanies { get; set; }
    public DbSet<RemittanceAdviceType> RemittanceAdviceTypes { get; set; }

    private static void ApplyPaymentFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BucketRemittanceAdvice>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<RemittanceAdvice>().HasQueryFilter(i => i.Buckets.Any());
        modelBuilder.Entity<RemittanceAdviceLine>().HasQueryFilter(i => i.RemittanceAdvice != null);
        modelBuilder.Entity<RemittanceAdviceCompany>().HasQueryFilter(i => i.RemittanceAdvice != null);
        modelBuilder.Entity<RemittanceAdviceReference>().HasQueryFilter(i => i.RemittanceAdvice != null);
        modelBuilder.Entity<RemittanceAdviceAuditItem>().HasQueryFilter(i => i.RemittanceAdvice != null);
    }

    private static void SeedPayments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RemittanceAdviceType>().HasData(new[] {
            new RemittanceAdviceType { Id = 1,  Name = "Statement" },
            new RemittanceAdviceType { Id = 2,  Name = "Payer Payment Advice" },
            new RemittanceAdviceType { Id = 3,  Name = "Payee Payment Advice" }
        });
    }

    public async ValueTask DeleteAllRemittanceAdviceForSystem(string sourceSystemId)
    {
        Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        _ = await Database.ExecuteSqlRawAsync(@"
DECLARE @SourceSystemId as nvarchar(255) = @p0;
DECLARE @RemittanceAdvices as TABLE(RemittanceAdviceId uniqueidentifier)

INSERT INTO @RemittanceAdvices
	SELECT Id FROM [Payments].[RemittanceAdvices] r WHERE r.SourceSystemId=@SourceSystemId

-- Delete buckets.
DELETE FROM [Masterdata].[BucketRemittanceAdvices] WHERE RemittanceAdviceId IN (SELECT RemittanceAdviceId FROM @RemittanceAdvices)
-- Delete audits.
DELETE FROM [Logging].[RemittanceAdviceAuditItems] WHERE RemittanceAdviceId IN (SELECT RemittanceAdviceId FROM @RemittanceAdvices)
-- Delete companies.
DELETE FROM [Payments].[RemittanceAdviceCompanies] WHERE RemittanceAdviceId IN (SELECT RemittanceAdviceId FROM @RemittanceAdvices)
-- Delete lines.
DELETE FROM [Payments].[RemittanceAdviceLines] WHERE RemittanceAdviceId IN (SELECT RemittanceAdviceId FROM @RemittanceAdvices)
-- Delete references.
DELETE FROM [Payments].[RemittanceAdviceReferences] WHERE RemittanceAdviceId IN (SELECT RemittanceAdviceId FROM @RemittanceAdvices)
-- Delete remmitance advice.
DELETE FROM [Payments].[RemittanceAdvices] WHERE Id IN (SELECT RemittanceAdviceId FROM @RemittanceAdvices)
", sourceSystemId);
    }
}