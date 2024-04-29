using B2B.Data.Brokers.Events.Masterdata.Interfaces;
using B2B.Objects.Entities.Masterdata;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Masterdata
{
    public class CompanyEventBroker : ICompanyEventBroker
    {
        private readonly IEventHub eventHub;

        public CompanyEventBroker(IEventHub eventHub) =>
            this.eventHub = eventHub;

        public async ValueTask RaiseCompanyAddEventAsync(EventMessage<Company> eventArgs) =>
            await eventHub.RaiseEventAsync("company_add", eventArgs);

        public async ValueTask RaiseCompanyDeleteEventAsync(EventMessage<Company> eventArgs) =>
            await eventHub.RaiseEventAsync("company_delete", eventArgs);

        public async ValueTask RaiseCompanyUpdateEventAsync(EventMessage<Company> eventArgs) =>
            await eventHub.RaiseEventAsync("company_update", eventArgs);

        public async ValueTask RaiseCompanyImportEventAsync(EventMessage<CompanyImportEventData> eventArgs) =>
            await eventHub.RaiseEventAsync("company_import", eventArgs);
    }

    public class CompanyImportEventData
    {
        public Company Company { get; set; }
        public Guid RootBucketId { get; set; }
        public string Perspective { get; set; }
    }
}