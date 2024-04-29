using B2B.Objects.Entities.Funding;

namespace B2B.Data.Brokers.Storages.Funding.Interfaces
{
    public interface IFundingDetailBroker
    {
        ValueTask<FundingDetail> AddFundingDetailAsync(FundingDetail fundingDetail);
        ValueTask DeleteFundingDetailAsync(FundingDetail fundingDetail);
        IQueryable<FundingDetail> GetAllFundingDetails();
        ValueTask<FundingDetail> UpdateFundingDetailAsync(FundingDetail fundingDetail);
    }
}