using B2B.Objects.Entities.Transactions;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.ActiveTransactions.Interfaces;

public interface IActiveTransactionEventBroker
{
    ValueTask RaiseActiveTransactionAddEventAsync(EventMessage<ActiveTransaction> eventArgs);
    ValueTask RaiseActiveTransactionUpdateEventAsync(EventMessage<ActiveTransaction> eventArgs);
    ValueTask RaiseActiveTransactionDeleteEventAsync(EventMessage<ActiveTransaction> eventArgs);
}