using B2B.Data.Brokers.Events.Import.Interfaces;
using B2B.Objects.Entities.Import;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Import;

public class CompanyCSVLineEventBroker : ICompanyCSVLineEventBroker
{
    private readonly IEventHub eventHub;

    public CompanyCSVLineEventBroker(IEventHub eventHub) =>
        this.eventHub = eventHub;

    public async ValueTask RaiseDeleteEvent(EventMessage<CompanyCSVLine> eventArgs) =>
        await eventHub.RaiseEventAsync("csvcompany_delete", eventArgs);

    public async ValueTask RaiseImportEvent(EventMessage<CompanyCSVLine> eventArgs) =>
        await eventHub.RaiseEventAsync("csvcompany_import", eventArgs);

    public async ValueTask RaiseImportEvents(EventMessage<IEnumerable<CompanyCSVLine>> eventArgs) =>
        await eventHub.RaiseEventAsync("csvcompany_bulk_import", eventArgs);
}