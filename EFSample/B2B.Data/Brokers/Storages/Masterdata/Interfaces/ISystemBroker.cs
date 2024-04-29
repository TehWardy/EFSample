using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Data.Brokers.Storages.Masterdata.Interfaces
{
    public interface ISystemBroker
    {
        ValueTask<B2BSystem> AddSystemAsync(B2BSystem userRole);
        ValueTask<B2BSystem> UpdateSystemAsync(B2BSystem userRole);
        ValueTask DeleteSystemAsync(B2BSystem userRole);
        IQueryable<B2BSystem> GetAllSystems();
    }
}
