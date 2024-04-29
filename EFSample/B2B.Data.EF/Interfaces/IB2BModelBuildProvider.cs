using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace B2B.Data.EF.Interfaces
{
    public interface IB2BModelBuildProvider
    {
        void Configure(DbContextOptionsBuilder optionsBuilder);
        void Create(ModelBuilder modelBuilder);
        void MigrateDatabase(DatabaseFacade database);
    }
}