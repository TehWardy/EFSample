using B2B.Data.Brokers.Events.Security.Interfaces;
using B2B.Objects.Entities.Masterdata;
using B2B.Objects.Entities.Security;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Security;

public class B2BRoleEventBroker : IB2BRoleEventBroker
{
    private readonly IEventHub eventHub;

    public B2BRoleEventBroker(IEventHub eventHub) =>
        this.eventHub = eventHub;

    public async ValueTask RaiseB2BRoleAddEvent(EventMessage<B2BRoleEventData> eventArgs) =>
        await eventHub.RaiseEventAsync("b2brole_add", eventArgs);

    public async ValueTask RaiseB2BRoleUpdateEvent(EventMessage<B2BRoleEventData> eventArgs) =>
        await eventHub.RaiseEventAsync("b2brole_update", eventArgs);

    public async ValueTask RaiseB2BRoleDeleteEvent(EventMessage<B2BRole> eventArgs) =>
        await eventHub.RaiseEventAsync("b2brole_delete", eventArgs);
}

public class B2BRoleEventData
{
    public B2BRole Role { get; set; }
    public Bucket Bucket { get; set; }
}