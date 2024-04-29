using B2B.Objects.Entities.Banking;
using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF;

public partial class B2BDbContext
{
    public DbSet<Bank> Banks { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<BankBranch> BankBranches { get; set; }
    public DbSet<Payee> Payees { get; set; }
    public DbSet<BucketBankAccount> BucketBankAccounts { get; set; }

    private static void ApplyBankingFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BucketBankAccount>().HasQueryFilter(bat => bat.Bucket != null);
    }
}