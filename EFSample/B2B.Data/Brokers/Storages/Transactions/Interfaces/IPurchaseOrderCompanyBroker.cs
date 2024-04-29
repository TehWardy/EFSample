using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions.Interfaces
{
    public interface IPurchaseOrderCompanyBroker
    {
        ValueTask<PurchaseOrderCompany> AddPurchaseOrderCompanyAsync(PurchaseOrderCompany purchaseOrderCompany);
        ValueTask DeletePurchaseOrderCompanyAsync(PurchaseOrderCompany purchaseOrderCompany);
        IQueryable<PurchaseOrderCompany> GetAllPurchaseOrderCompanys();
        ValueTask<PurchaseOrderCompany> UpdatePurchaseOrderCompanyAsync(PurchaseOrderCompany purchaseOrderCompany);
    }
}