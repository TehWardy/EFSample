using B2B.Objects.Entities.Funding;
using B2B.Objects.Entities.Funding.Offer;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        public static void ConfigureFinancingModel(ModelBuilder modelBuilder)
        {
            ConfigureOffers(modelBuilder);
            ConfigureOfferCompanies(modelBuilder);
            ConfigureOfferDataItems(modelBuilder);
            ConfigureOfferLines(modelBuilder);
            ConfigureOfferReferences(modelBuilder);
            ConfigureFundingDetails(modelBuilder);
            ConfigureRates(modelBuilder);
        }

        private static void ConfigureRates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>()
                .ToTable("Rates", "Finance");

            modelBuilder.Entity<Rate>()
                .Property(r => r.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Rate>()
                .HasKey(r => r.Id);
        }

        private static void ConfigureFundingDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FundingDetail>()
                .ToTable("FundingDetails", "Finance");

            modelBuilder.Entity<FundingDetail>()
                .HasKey(fd => fd.Id);

            modelBuilder.Entity<FundingDetail>()
                .Property(fd => fd.CreatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<FundingDetail>()
                .Property(fd => fd.LastUpdatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<FundingDetail>()
                .Property(fd => fd.CurrentLimit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<FundingDetail>()
                .Property(fd => fd.Limit)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<FundingDetail>()
                .HasOne(fd => fd.System)
                .WithMany(s => s.FundingDetails);

            modelBuilder.Entity<FundingDetail>()
                .HasOne(fd => fd.Currency)
                .WithMany(c => c.FundingDetails);

            modelBuilder.Entity<FundingDetail>()
                .HasOne(fd => fd.FundingTypeBucket)
                .WithMany(b => b.FundingDetails);
        }

        private static void ConfigureOfferReferences(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfferReference>()
                .ToTable("OfferReferences", "Finance");

            modelBuilder.Entity<OfferReference>()
                            .HasKey(or => or.Id);

            modelBuilder.Entity<OfferReference>()
                .Property(or => or.Id)
                .HasMaxLength(100);

            modelBuilder.Entity<OfferReference>()
                .Property(or => or.SystemId)
                .IsRequired();

            modelBuilder.Entity<OfferReference>()
                .Property(or => or.Value)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<OfferReference>()
                .HasOne(or => or.System)
                .WithMany(s => s.OfferReferences);

            modelBuilder.Entity<OfferReference>()
                .HasOne(or => or.Offer)
                .WithMany(o => o.References);

            modelBuilder.Entity<OfferReference>()
                .HasMany(or => or.RemittanceAdviceLines)
                .WithOne(raLine => raLine.OfferReference);
        }

        private static void ConfigureOfferLines(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfferLine>()
                .ToTable("OfferLines", "Finance");

            modelBuilder.Entity<OfferLine>()
                .HasKey(ol => ol.Id);

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.LinePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.ProductCode)
                .HasMaxLength(50);

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.UnitPrice)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.Quantity)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.TaxRate)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.TaxFee)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.TaxableAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.TaxAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.TransactionValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.FundableValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.Rate)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<OfferLine>()
                .Property(ol => ol.Cost)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<OfferLine>()
                .HasOne(ol => ol.Currency)
                .WithMany(c => c.OfferLines);

            modelBuilder.Entity<OfferLine>()
                .HasOne(ol => ol.Offer)
                .WithMany(o => o.Lines);

            modelBuilder.Entity<OfferLine>()
                .HasOne(ol => ol.InvoiceReference)
                .WithMany(ir => ir.OfferLines);

            modelBuilder.Entity<OfferLine>()
                .HasOne(ol => ol.CreditReference)
                .WithMany(cr => cr.OfferLines);
        }

        private static void ConfigureOfferDataItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfferDataItem>()
                .ToTable("OfferDataItems", "Finance");

            modelBuilder.Entity<OfferDataItem>()
                            .HasKey(odi => odi.Id);

            modelBuilder.Entity<OfferDataItem>()
                .Property(odi => odi.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OfferDataItem>()
                .Property(odi => odi.Key)
                .IsRequired();

            modelBuilder.Entity<OfferDataItem>()
                .Property(odi => odi.Value)
                .IsRequired();

            modelBuilder.Entity<OfferDataItem>()
                .HasOne(odi => odi.Offer)
                .WithMany(o => o.Data);
        }

        private static void ConfigureOfferCompanies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfferCompany>()
                .ToTable("OfferCompanies", "Finance");

            modelBuilder.Entity<OfferCompany>()
                            .HasKey(oc => oc.Id);

            modelBuilder.Entity<OfferCompany>()
                .Property(oc => oc.Id)
                .HasMaxLength(110);

            modelBuilder.Entity<OfferCompany>()
                .Property(oc => oc.CompanyReferenceId)
                .IsRequired();

            modelBuilder.Entity<OfferCompany>()
                .HasOne(oc => oc.CompanyReference)
                .WithMany(cr => cr.OfferReferences);

            modelBuilder.Entity<OfferCompany>()
                .HasOne(oc => oc.Offer)
                .WithMany(o => o.Companies);
        }

        private static void ConfigureOffers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>()
                .ToTable("Offers", "Finance");

            modelBuilder.Entity<Offer>()
                            .HasKey(o => o.Id);

            modelBuilder.Entity<Offer>()
                .Property(o => o.SourceSystemId)
                .IsRequired();

            modelBuilder.Entity<Offer>()
                .Property(o => o.CurrencyId)
                .IsRequired();

            modelBuilder.Entity<Offer>()
                .Property(o => o.DebtorState)
                .HasMaxLength(50);

            modelBuilder.Entity<Offer>()
                .Property(o => o.CreditorState)
                .HasMaxLength(50);

            modelBuilder.Entity<Offer>()
                .Property(o => o.Comment)
                .HasMaxLength(500);

            modelBuilder.Entity<Offer>()
                .Property(o => o.Number)
                .HasMaxLength(50);

            modelBuilder.Entity<Offer>()
                .Property(o => o.DebtorName)
                .HasMaxLength(200);

            modelBuilder.Entity<Offer>()
                .Property(o => o.CreditorName)
                .HasMaxLength(200);

            modelBuilder.Entity<Offer>()
                .Property(o => o.DebtorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<Offer>()
                .Property(o => o.CreditorExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<Offer>()
                .Property(o => o.FunderName)
                .HasMaxLength(200);

            modelBuilder.Entity<Offer>()
                .Property(o => o.FunderState)
                .HasMaxLength(50);

            modelBuilder.Entity<Offer>()
                .Property(o => o.FunderExternalState)
                .HasMaxLength(50);

            modelBuilder.Entity<Offer>()
                .Property(o => o.Value)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Offer>()
                .Property(o => o.TransactionValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Offer>()
                .Property(o => o.FundableValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Offer>()
                .Property(o => o.Rate)
                .HasColumnType("decimal(18,6)");

            modelBuilder.Entity<Offer>()
                .Property(o => o.Cost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.SourceSystem)
                .WithMany(s => s.Offers);

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Currency)
                .WithMany(c => c.Offers);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.Data)
                .WithOne(d => d.Offer);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.AuditTrail)
                .WithOne(a => a.Offer);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.Lines)
                .WithOne(l => l.Offer);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.References)
                .WithOne(r => r.Offer);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.Companies)
                .WithOne(oc => oc.Offer);

            modelBuilder.Entity<Offer>()
                .HasMany(o => o.Buckets)
                .WithOne(b => b.Offer);
        }
    }
}