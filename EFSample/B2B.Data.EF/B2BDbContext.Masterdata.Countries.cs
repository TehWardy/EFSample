using B2B.Objects.Entities.Masterdata;
using Microsoft.EntityFrameworkCore;

namespace B2B.Data.EF
{
    public partial class B2BDbContext
    {
        private static void ConfigureCountries(ModelBuilder modelBuilder)
        {

        }

        private static void SeedCountries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(B2B.Countries.All);
        }
    }
}