using B2B.Data.Brokers.Events.Masterdata.Interfaces;
using B2B.Objects.Entities.Masterdata;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Masterdata;

public class BucketEventBroker : IBucketEventBroker
{
    private readonly IEventHub eventHub;

    public BucketEventBroker(IEventHub eventHub) =>
        this.eventHub = eventHub;

    public async ValueTask RaiseAddEventAsync(EventMessage<BucketEventData> eventArgs) =>
        await eventHub.RaiseEventAsync("bucket_add", eventArgs);

    public async ValueTask RaiseImportEventAsync(EventMessage<Bucket> eventArgs) =>
        await eventHub.RaiseEventAsync("bucket_import", eventArgs);

    public async ValueTask RaiseUpdateEventAsync(EventMessage<BucketEventData> eventArgs) =>
        await eventHub.RaiseEventAsync("bucket_update", eventArgs);

    public async ValueTask RaiseDeleteEventAsync(EventMessage<Bucket> eventArgs) =>
        await eventHub.RaiseEventAsync("bucket_delete", eventArgs);
}

public class BucketEventData
{
    public Bucket Bucket { get; set; }
    public Company Company { get; set; }
}