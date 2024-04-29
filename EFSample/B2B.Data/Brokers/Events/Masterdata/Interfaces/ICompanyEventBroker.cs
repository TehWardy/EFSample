using B2B.Objects.Entities.Masterdata;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Masterdata.Interfaces
{
    public interface ICompanyEventBroker
    {
        ValueTask RaiseCompanyAddEventAsync(EventMessage<Company> eventArgs);
        ValueTask RaiseCompanyUpdateEventAsync(EventMessage<Company> eventArgs);
        ValueTask RaiseCompanyDeleteEventAsync(EventMessage<Company> eventArgs);
        ValueTask RaiseCompanyImportEventAsync(EventMessage<CompanyImportEventData> eventArgs);
    }
}