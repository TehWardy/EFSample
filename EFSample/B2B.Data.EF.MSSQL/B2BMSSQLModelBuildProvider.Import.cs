using B2B.Objects.Entities.Import;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        private static void ConfigureImports(ModelBuilder modelBuilder)
        {
            ConfigureCompanyCSVLines(modelBuilder);
            ConfigureTransactionCSVLines(modelBuilder);
        }

        private static void ConfigureCompanyCSVLines(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyCSVLine>().ToTable("CompanyCSVLines", "Import");
            modelBuilder.Entity<CompanyCSVLine>().HasKey(k => k.Id);
            modelBuilder.Entity<CompanyCSVLine>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CompanyCSVLine>()
                .HasOne(c => c.RootBucket)
                .WithMany(c => c.CompanyCSVLines);
        }

        private static void ConfigureTransactionCSVLines(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionCSVLine>().HasKey(e => e.Id);
            modelBuilder.Entity<TransactionCSVLine>().ToTable("TransactionCSVLines", "Import");
            modelBuilder.Entity<TransactionCSVLine>()
                .HasOne(c => c.RootBucket)
                .WithMany(c => c.TransactionCSVLines);

            modelBuilder.Entity<TransactionCSVLine>()
                .Property(at => at.GrossValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TransactionCSVLine>()
                .Property(at => at.TaxValue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TransactionCSVLine>()
                .Property(at => at.Value)
                .HasColumnType("decimal(18,2)");
        }
    }
}