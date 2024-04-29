using B2B.Objects.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        private static void ConfigureSecurityModel(ModelBuilder modelBuilder)
        {
            ConfigureSecurityTables(modelBuilder);
            ConfigureSecurityColumns(modelBuilder);
            ConfigureSecurityForeignKeys(modelBuilder);
        }

        private static void ConfigureSecurityTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<B2BRole>()
                .ToTable("Roles", "Security");

            modelBuilder.Entity<B2BUser>()
                .ToTable("Users", "Security");

            modelBuilder.Entity<B2BUserRole>()
                .ToTable("UserRoles", "Security");

        }

        private static void ConfigureSecurityColumns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<B2BRole>()
                .HasKey(role => role.Id);

            modelBuilder.Entity<B2BRole>()
                .Property(role => role.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<B2BRole>()
                .Property(role => role.Name)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<B2BRole>()
                .Property(role => role.Description)
                .HasMaxLength(256);

            modelBuilder.Entity<B2BRole>()
                .Property(role => role.CreatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<B2BRole>()
                .Property(role => role.LastUpdatedBy)
                .HasMaxLength(100);

            modelBuilder.Entity<B2BUser>()
                .HasKey(ur => ur.Id);

            modelBuilder.Entity<B2BUser>()
                .Property(bu => bu.DisplayName)
                .HasMaxLength(50);

            modelBuilder.Entity<B2BUser>()
                .Property(bu => bu.EmailAddress)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<B2BUser>()
                .Property(bu => bu.JobTitle)
                .HasMaxLength(60);



        }

        private static void ConfigureSecurityForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<B2BUserRole>()
                .HasKey(i => new { i.UserId, i.RoleId });

            modelBuilder.Entity<B2BUserRole>()
                .HasOne(bur => bur.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(bur => bur.RoleId);

            modelBuilder.Entity<B2BUserRole>()
                .HasIndex(ur => ur.UserId);

            modelBuilder.Entity<B2BUserRole>()
                .HasIndex(ur => ur.RoleId);

            modelBuilder.Entity<B2BUserRole>()
                .HasOne(bur => bur.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(bur => bur.UserId);

            modelBuilder.Entity<B2BRole>()
                .HasMany(role => role.Buckets)
                .WithOne(br => br.Role)
                .HasForeignKey(br => br.RoleId);

            modelBuilder.Entity<B2BRole>()
                .HasMany(role => role.Users)
                .WithOne(bur => bur.Role)
                .HasForeignKey(bur => bur.RoleId);

            modelBuilder.Entity<B2BUser>()
                .HasOne(bu => bu.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(bu => bu.AddressId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(bu => bu.Roles)
                .WithOne(bur => bur.User)
                .HasForeignKey(bur => bur.UserId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(bu => bu.Buckets)
                .WithOne(bu => bu.User)
                .HasForeignKey(bu => bu.UserId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(bu => bu.CreditAuditItems)
                .WithOne(cai => cai.User)
                .HasForeignKey(cai => cai.UserId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(bu => bu.InvoiceAuditItems)
                .WithOne(iai => iai.User)
                .HasForeignKey(iai => iai.UserId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(bu => bu.OfferAuditItems)
                .WithOne(oai => oai.User)
                .HasForeignKey(oai => oai.UserId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(bu => bu.PurchaseOrderAuditItems)
                .WithOne(poai => poai.User)
                .HasForeignKey(poai => poai.UserId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(bu => bu.RemittanceAdviceAuditItems)
                .WithOne(raai => raai.User)
                .HasForeignKey(raai => raai.UserId);

            modelBuilder.Entity<B2BUser>()
                .HasMany(u => u.RAHeads)
                .WithOne(ra => ra.B2BUser)
                .HasForeignKey(ra => ra.B2BUserId);
        }

        private static void ConfigureSecurity(ModelBuilder modelBuilder)
            => ConfigureSecurityModel(modelBuilder);
    }
}