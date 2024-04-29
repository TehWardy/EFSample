using B2B.Data.Brokers.Events.Masterdata.Interfaces;
using EventLibrary;
using EventLibrary.Objects;
using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Data.Brokers.Events.Masterdata;

public class SystemEventBroker(IEventHub eventHub) : ISystemEventBroker
{
    public async ValueTask RaiseAddEvent(EventMessage<B2BSystem> eventArgs) =>
        await eventHub.RaiseEventAsync("system_add", eventArgs);

    public async ValueTask RaiseDeleteEvent(EventMessage<B2BSystem> eventArgs) =>
        await eventHub.RaiseEventAsync("system_delete", eventArgs);

    public async ValueTask RaiseUpdateEvent(EventMessage<B2BSystem> eventArgs) =>
        await eventHub.RaiseEventAsync("system_update", eventArgs);
}