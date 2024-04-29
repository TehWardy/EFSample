using B2B.Data.Brokers.Storages.Transactions.Interfaces;
using B2B.Data.EF;
using B2B.Data.EF.Interfaces;
using B2B.Objects.Entities;

namespace B2B.Data.Brokers.Storages.Transactions
{
    public class PurchaseOrderCompanyBroker : IPurchaseOrderCompanyBroker
    {
        private readonly IB2BDbContextFactory contextFactory;
        private B2BDbContext readContext;

        public PurchaseOrderCompanyBroker(IB2BDbContextFactory contextFactory) =>
            this.contextFactory = contextFactory;

        public async ValueTask<PurchaseOrderCompany> AddPurchaseOrderCompanyAsync(PurchaseOrderCompany purchaseOrderCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = await context.PurchaseOrderCompanies.AddAsync(purchaseOrderCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<PurchaseOrderCompany> UpdatePurchaseOrderCompanyAsync(PurchaseOrderCompany purchaseOrderCompany)
        {
            using var context = contextFactory.CreateDbContext();
            var entityEntry = context.PurchaseOrderCompanies.Update(purchaseOrderCompany);
            await context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask DeletePurchaseOrderCompanyAsync(PurchaseOrderCompany purchaseOrderCompany)
        {
            using var context = contextFactory.CreateDbContext();
            context.PurchaseOrderCompanies.Remove(purchaseOrderCompany);
            await context.SaveChangesAsync();
        }

        public IQueryable<PurchaseOrderCompany> GetAllPurchaseOrderCompanys()
        {
            readContext ??= contextFactory.CreateDbContext();
            return readContext.PurchaseOrderCompanies;
        }
    }
}