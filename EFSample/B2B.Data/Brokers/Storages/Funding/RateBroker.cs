using B2B.Data.Brokers.Storages.Funding.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Funding;

namespace B2B.Data.Brokers.Storages.Funding
{
    public class RateBroker : IRateBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public RateBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<Rate> AddRateAsync(Rate rate)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.Rates.AddAsync(rate);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<Rate> UpdateRateAsync(Rate rate)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.Rates.Update(rate);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteRateAsync(Rate rate)
        {
            using var context = contextFactory.CreateDbContext();
            context.Rates.Remove(new Rate() { Id = rate.Id });
            await context.SaveChangesAsync();
        }

        public IQueryable<Rate> GetAllRates()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.Rates;
        }
    }
}