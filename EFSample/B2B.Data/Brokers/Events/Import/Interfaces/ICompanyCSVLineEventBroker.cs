using B2B.Objects.Entities.Import;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Import.Interfaces;

public interface ICompanyCSVLineEventBroker
{
    ValueTask RaiseImportEvents(EventMessage<IEnumerable<CompanyCSVLine>> eventArgs);
    ValueTask RaiseImportEvent(EventMessage<CompanyCSVLine> eventArgs);
    ValueTask RaiseDeleteEvent(EventMessage<CompanyCSVLine> eventArgs);
}