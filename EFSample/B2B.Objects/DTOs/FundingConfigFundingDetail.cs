namespace B2B.Objects.DTOs;

public class FundingConfigFundingDetail
{
    public string SystemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CurrencyId { get; set; }
    public decimal Limit { get; set; }
    public Boolean IsSystematic { get; set; }
    public string Formula { get; set; }
    public string BuyerReferenceId { get; set; }
    public string SupplierReferenceId { get; set; }
    public string FunderReferenceId { get; set; }
}
