using EventLibrary.Objects;
using B2BSystem = B2B.Objects.Entities.Masterdata.System;

namespace B2B.Data.Brokers.Events.Masterdata.Interfaces;

public interface ISystemEventBroker
{
    ValueTask RaiseAddEvent(EventMessage<B2BSystem> eventArgs);
    ValueTask RaiseUpdateEvent(EventMessage<B2BSystem> eventArgs);
    ValueTask RaiseDeleteEvent(EventMessage<B2BSystem> eventArgs);
}