using B2B.Objects.Entities.Banking;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BMSSQLModelBuildProvider
    {
        public static void ConfigureBankingModel(ModelBuilder modelBuilder)
        {
            ConfigureBankingTables(modelBuilder);
            ConfigureBankingColumns(modelBuilder);
            ConfigureBankingForeignKeys(modelBuilder);
        }

        public static void ConfigureBankingTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .ToTable("Banks", "Banking");

            modelBuilder.Entity<BankAccount>()
                .ToTable("BankAccounts", "Banking");

            modelBuilder.Entity<BankBranch>()
                .ToTable("BankBranches", "Banking");

            modelBuilder.Entity<Payee>()
                .ToTable("Payees", "Banking");

            modelBuilder.Entity<BucketBankAccount>()
                .ToTable("BucketBankAccounts", "Banking");
        }

        public static void ConfigureBankingColumns(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Bank>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Bank>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<BankAccount>()
                .HasKey(ba => ba.Id);

            modelBuilder.Entity<BankAccount>()
                .Property(ba => ba.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BankAccount>()
                .Property(ba => ba.AccountNumber)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<BankAccount>()
                .Property(ba => ba.AccountName)
                .HasMaxLength(40);

            modelBuilder.Entity<BankBranch>()
                .HasKey(bb => bb.Id);

            modelBuilder.Entity<BankBranch>()
                .Property(bb => bb.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<BankBranch>().Property(bb => bb.Name).HasMaxLength(100);
            modelBuilder.Entity<Payee>().HasKey(p => p.Id);
            modelBuilder.Entity<Payee>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Payee>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Payee>()
                .Property(p => p.PaymentText)
                .HasMaxLength(40);

            modelBuilder.Entity<BucketBankAccount>()
                .HasKey(i => new { i.BucketId, i.BankAccountId });
        }

        public static void ConfigureBankingForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .HasOne(b => b.Address)
                .WithMany(a => a.Banks);

            modelBuilder.Entity<Bank>()
                .HasMany(b => b.Branches)
                .WithOne(bb => bb.Bank);

            modelBuilder.Entity<BankAccount>()
                .HasOne(ba => ba.BankBranch)
                .WithMany(bb => bb.Accounts);

            modelBuilder.Entity<BankAccount>()
                .HasMany(ba => ba.Payees)
                .WithOne(p => p.BankAccount);

            modelBuilder.Entity<BankAccount>()
                .HasMany(ba => ba.DebtorPayments)
                .WithOne(raLine => raLine.DebtorAccount);

            modelBuilder.Entity<BankAccount>()
                .HasMany(ba => ba.CreditorPayments)
                .WithOne(raLine => raLine.CreditorAccount);

            modelBuilder.Entity<BankAccount>()
                .HasMany(ba => ba.Buckets)
                .WithOne(b => b.BankAccount);

            modelBuilder.Entity<BankBranch>()
                .HasOne(bb => bb.Bank)
                .WithMany(b => b.Branches);

            modelBuilder.Entity<BankBranch>()
                .HasOne(bb => bb.Address)
                .WithMany(bb => bb.BankBranches);

            modelBuilder.Entity<BankBranch>()
                .HasMany(bb => bb.Accounts)
                .WithOne(ba => ba.BankBranch);

            modelBuilder.Entity<Payee>()
                .HasOne(p => p.Address)
                .WithMany(a => a.Payees);

            modelBuilder.Entity<Payee>()
                .HasOne(p => p.BankAccount)
                .WithMany(a => a.Payees);

            modelBuilder.Entity<Payee>()
                .HasMany(p => p.Companies)
                .WithOne(c => c.Payee);

            modelBuilder.Entity<Payee>()
                .HasMany(p => p.Buckets)
                .WithOne(b => b.Payee);

            modelBuilder.Entity<BucketBankAccount>()
                .HasOne(baa => baa.Bucket)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(baa => baa.BucketId);

            modelBuilder.Entity<BucketBankAccount>()
                .HasOne(baa => baa.BankAccount)
                .WithMany(ba => ba.Buckets)
                .HasForeignKey(baa => baa.BankAccountId);
        }
    }
}

