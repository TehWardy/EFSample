using B2B.Objects.Entities.Funding;
using B2B.Objects.Entities.Funding.Offer;
using B2B.Objects.Entities.Logging;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF;

public partial class B2BDbContext
{
    // Financing primary entities
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Rate> Rates { get; set; }

    // Financing secondary entities
    public DbSet<FundingDetail> FundingDetails { get; set; }
    public DbSet<OfferLine> OfferLines { get; set; }
    public DbSet<OfferReference> OfferReferences { get; set; }
    public DbSet<OfferCompany> OfferCompanies { get; set; }

    private static void ApplyFinancingFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BucketOffer>().HasQueryFilter(i => i.Bucket != null);
        modelBuilder.Entity<FundingDetail>().HasQueryFilter(i => i.FundingTypeBucket != null);
        modelBuilder.Entity<Offer>().HasQueryFilter(i => i.Buckets.Count != 0);
        modelBuilder.Entity<OfferLine>().HasQueryFilter(i => i.Offer != null);
        modelBuilder.Entity<OfferCompany>().HasQueryFilter(i => i.Offer != null);
        modelBuilder.Entity<OfferReference>().HasQueryFilter(i => i.Offer != null);
        modelBuilder.Entity<OfferDataItem>().HasQueryFilter(odi => odi.Offer != null);
        modelBuilder.Entity<OfferAuditItem>().HasQueryFilter(i => i.Offer != null);
    }

    public async ValueTask DeleteAllOffersForSystem(string sourceSystemId)
    {
        Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        _ = await Database.ExecuteSqlRawAsync(@"
DECLARE @SourceSystemId as nvarchar(255) = @p0;
DECLARE @Offers as TABLE(OfferId uniqueidentifier)

INSERT INTO @Offers
	SELECT Id FROM [Finance].[Offers] o WHERE o.SourceSystemId=@SourceSystemId

-- Delete buckets.
DELETE FROM [Masterdata].[BucketOffers] WHERE OfferId IN (SELECT OfferId FROM @Offers)

-- Delete audits.
DELETE FROM [Logging].[OfferAuditItems] WHERE OfferId IN (SELECT OfferId FROM @Offers)

-- Delete companies.
DELETE FROM [Finance].[OfferCompanies] WHERE OfferId IN (SELECT OfferId FROM @Offers)

-- Delete lines.
DELETE FROM [Finance].[OfferLines] WHERE OfferId IN (SELECT OfferId FROM @Offers)

-- Delete references.
DELETE FROM [Finance].[OfferReferences] WHERE OfferId IN (SELECT OfferId FROM @Offers)

-- Delete offers.
DELETE FROM [Finance].[Offers] WHERE Id IN (SELECT OfferId FROM @Offers)
", sourceSystemId);
    }
}