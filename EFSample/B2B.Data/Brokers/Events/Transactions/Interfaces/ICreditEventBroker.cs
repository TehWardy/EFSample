using B2B.Objects.Entities.Transactions;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Transactions.Interfaces;

public interface ICreditEventBroker
{
    ValueTask RaiseCreditAddEventAsync(EventMessage<Credit> eventArgs);
    ValueTask RaiseCreditUpdateEventAsync(EventMessage<Credit> eventArgs);
    ValueTask RaiseCreditDeleteEventAsync(EventMessage<Credit> eventArgs);
}
