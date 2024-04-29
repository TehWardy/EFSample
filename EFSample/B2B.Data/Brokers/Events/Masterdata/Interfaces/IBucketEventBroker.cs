using B2B.Objects.Entities.Masterdata;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Masterdata.Interfaces;

public interface IBucketEventBroker
{
    ValueTask RaiseAddEventAsync(EventMessage<BucketEventData> eventArgs);
    ValueTask RaiseImportEventAsync(EventMessage<Bucket> eventArgs);
    ValueTask RaiseUpdateEventAsync(EventMessage<BucketEventData> eventArgs);
    ValueTask RaiseDeleteEventAsync(EventMessage<Bucket> eventArgs);
}