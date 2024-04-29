namespace B2B.Data.EF.Interfaces
{
    public interface IB2BDbContextFactory
    {
        B2BDbContext CreateDbContext();
    }
}