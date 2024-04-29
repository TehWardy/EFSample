using B2B.Data.Brokers.Storages.Funding.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities.Funding;

namespace B2B.Data.Brokers.Storages.Funding
{
    public class FundingDetailBroker : IFundingDetailBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public FundingDetailBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<FundingDetail> AddFundingDetailAsync(FundingDetail fundingDetail)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.FundingDetails.AddAsync(fundingDetail);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<FundingDetail> UpdateFundingDetailAsync(FundingDetail fundingDetail)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.FundingDetails.Update(fundingDetail);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeleteFundingDetailAsync(FundingDetail fundingDetail)
        {
            using var context = contextFactory.CreateDbContext();
            context.FundingDetails.Remove(fundingDetail);
            await context.SaveChangesAsync();
        }

        public IQueryable<FundingDetail> GetAllFundingDetails()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.FundingDetails;
        }
    }
}