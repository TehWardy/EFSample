using B2B.Objects.Entities.Security;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Security.Interfaces;

public interface IB2BRoleEventBroker
{
    ValueTask RaiseB2BRoleAddEvent(EventMessage<B2BRoleEventData> eventArgs);
    ValueTask RaiseB2BRoleUpdateEvent(EventMessage<B2BRoleEventData> eventArgs);
    ValueTask RaiseB2BRoleDeleteEvent(EventMessage<B2BRole> eventArgs);
}