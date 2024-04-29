using B2B.Objects.Entities.Logging;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        public static void ConfigureAuditingModel(ModelBuilder modelBuilder)
        {
            ConfigureAuditingTables(modelBuilder);
            ConfigureAuditingColumns(modelBuilder);
            ConfigureAuditingForeignKeys(modelBuilder);
        }

        public static void ConfigureAuditingTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditAuditItem>()
                .ToTable("CreditAuditItems", "Logging");

            modelBuilder.Entity<InvoiceAuditItem>()
                .ToTable("InvoiceAuditItems", "Logging");

            modelBuilder.Entity<OfferAuditItem>()
                .ToTable("OfferAuditItems", "Logging");

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .ToTable("PurchaseOrderAuditItems", "Logging");

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .ToTable("RemittanceAdviceAuditItems", "Logging");

            modelBuilder.Entity<AuditItemLevel>()
                .ToTable("AuditItemLevels", "Logging");
        }

        public static void ConfigureAuditingColumns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditAuditItem>()
                .HasKey(cai => cai.Id);

            modelBuilder.Entity<CreditAuditItem>()
                .Property(cai => cai.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CreditAuditItem>()
                .Property(cai => cai.Source)
                .HasMaxLength(100);

            modelBuilder.Entity<CreditAuditItem>()
                .Property(cai => cai.Reference)
                .HasMaxLength(100);

            modelBuilder.Entity<CreditAuditItem>()
                .Property(cai => cai.Message)
                .HasMaxLength(1000);

            modelBuilder.Entity<InvoiceAuditItem>()
                .HasKey(iai => iai.Id);

            modelBuilder.Entity<InvoiceAuditItem>()
                .Property(iai => iai.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<InvoiceAuditItem>()
                .Property(iai => iai.Source)
                .HasMaxLength(100);

            modelBuilder.Entity<InvoiceAuditItem>()
                .Property(iai => iai.Reference)
                .HasMaxLength(100);

            modelBuilder.Entity<InvoiceAuditItem>()
                .Property(iai => iai.Message)
                .HasMaxLength(1000);

            modelBuilder.Entity<OfferAuditItem>()
                .HasKey(oai => oai.Id);

            modelBuilder.Entity<OfferAuditItem>()
                .Property(oai => oai.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OfferAuditItem>()
                .Property(iai => iai.Source)
                .HasMaxLength(100);

            modelBuilder.Entity<OfferAuditItem>()
                .Property(iai => iai.Reference)
                .HasMaxLength(100);

            modelBuilder.Entity<OfferAuditItem>()
                .Property(iai => iai.Message)
                .HasMaxLength(1000);

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .HasKey(poai => poai.Id);

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .Property(poai => poai.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .Property(iai => iai.Source)
                .HasMaxLength(100);

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .Property(iai => iai.Reference)
                .HasMaxLength(100);

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .Property(iai => iai.Message)
                .HasMaxLength(1000);

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .HasKey(raai => raai.Id);

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .Property(raai => raai.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .Property(iai => iai.Source)
                .HasMaxLength(100);

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .Property(iai => iai.Reference)
                .HasMaxLength(100);

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .Property(iai => iai.Message)
                .HasMaxLength(1000);

            modelBuilder.Entity<AuditItemLevel>()
                .HasKey(ail => ail.Id);

            modelBuilder.Entity<AuditItemLevel>()
                .Property(ail => ail.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

        public static void ConfigureAuditingForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditAuditItem>()
                .HasOne(cai => cai.AuditItemLevel)
                .WithMany(ail => ail.CreditAuditItems);

            modelBuilder.Entity<CreditAuditItem>()
                .HasOne(cai => cai.User)
                .WithMany(u => u.CreditAuditItems);

            modelBuilder.Entity<CreditAuditItem>()
                .HasOne(cai => cai.Credit)
                .WithMany(c => c.AuditTrail);

            modelBuilder.Entity<InvoiceAuditItem>()
                .HasOne(iai => iai.User)
                .WithMany(u => u.InvoiceAuditItems);

            modelBuilder.Entity<InvoiceAuditItem>()
                .HasOne(iai => iai.AuditItemLevel)
                .WithMany(ail => ail.InvoiceAuditItems);

            modelBuilder.Entity<InvoiceAuditItem>()
                .HasOne(iai => iai.Invoice)
                .WithMany(i => i.AuditTrail);

            modelBuilder.Entity<OfferAuditItem>()
                .HasOne(oai => oai.User)
                .WithMany(u => u.OfferAuditItems);

            modelBuilder.Entity<OfferAuditItem>()
                .HasOne(oai => oai.AuditItemLevel)
                .WithMany(ail => ail.OfferAuditItems);

            modelBuilder.Entity<OfferAuditItem>()
                .HasOne(oai => oai.Offer)
                .WithMany(o => o.AuditTrail);

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .HasOne(poai => poai.User)
                .WithMany(u => u.PurchaseOrderAuditItems);

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .HasOne(poai => poai.AuditItemLevel)
                .WithMany(ail => ail.PurchaseOrderAuditItems);

            modelBuilder.Entity<PurchaseOrderAuditItem>()
                .HasOne(poai => poai.PurchaseOrder)
                .WithMany(p => p.AuditTrail);

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .HasOne(raai => raai.User)
                .WithMany(u => u.RemittanceAdviceAuditItems);

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .HasOne(raai => raai.AuditItemLevel)
                .WithMany(ail => ail.RemittanceAdviceAuditItems);

            modelBuilder.Entity<RemittanceAdviceAuditItem>()
                .HasOne(raai => raai.RemittanceAdvice)
                .WithMany(ra => ra.AuditTrail);

            modelBuilder.Entity<AuditItemLevel>()
                .HasMany(ail => ail.InvoiceAuditItems)
                .WithOne(iai => iai.AuditItemLevel);

            modelBuilder.Entity<AuditItemLevel>()
                .HasMany(ail => ail.CreditAuditItems)
                .WithOne(cai => cai.AuditItemLevel);

            modelBuilder.Entity<AuditItemLevel>()
                .HasMany(ail => ail.OfferAuditItems)
                .WithOne(oai => oai.AuditItemLevel);

            modelBuilder.Entity<AuditItemLevel>()
                .HasMany(ail => ail.PurchaseOrderAuditItems)
                .WithOne(poai => poai.AuditItemLevel);

            modelBuilder.Entity<AuditItemLevel>()
                .HasMany(ail => ail.RemittanceAdviceAuditItems)
                .WithOne(raai => raai.AuditItemLevel);
        }

        private void ConfigureAuditing(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceAuditItem>().HasOne(p => p.Invoice).WithMany(a => a.AuditTrail);
            modelBuilder.Entity<CreditAuditItem>().HasOne(p => p.Credit).WithMany(a => a.AuditTrail);
            modelBuilder.Entity<PurchaseOrderAuditItem>().HasOne(p => p.PurchaseOrder).WithMany(a => a.AuditTrail);
            modelBuilder.Entity<OfferAuditItem>().HasOne(p => p.Offer).WithMany(a => a.AuditTrail);
            modelBuilder.Entity<RemittanceAdviceAuditItem>().HasOne(p => p.RemittanceAdvice).WithMany(a => a.AuditTrail);
        }

        private void ApplyAuditingFilters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceAuditItem>().HasQueryFilter(iai => iai.Invoice != null);
            modelBuilder.Entity<CreditAuditItem>().HasQueryFilter(cai => cai.Credit != null);
            modelBuilder.Entity<PurchaseOrderAuditItem>().HasQueryFilter(poai => poai.PurchaseOrder != null);
            modelBuilder.Entity<OfferAuditItem>().HasQueryFilter(oai => oai.Offer != null);
            modelBuilder.Entity<RemittanceAdviceAuditItem>().HasQueryFilter(raai => raai.RemittanceAdvice != null);
        }
    }
}