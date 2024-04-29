using B2B.Data.Brokers.Events.ActiveTransactions.Interfaces;
using B2B.Objects.Entities.Transactions;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.ActiveTransactions;

public class ActiveTransactionEventBroker : IActiveTransactionEventBroker
{
    private readonly IEventHub eventHub;

    public ActiveTransactionEventBroker(IEventHub eventHub) =>
        this.eventHub = eventHub;

    public async ValueTask RaiseActiveTransactionAddEventAsync(EventMessage<ActiveTransaction> eventArgs) =>
        await eventHub.RaiseEventAsync("activetransaction_add", eventArgs);

    public async ValueTask RaiseActiveTransactionDeleteEventAsync(EventMessage<ActiveTransaction> eventArgs) =>
        await eventHub.RaiseEventAsync("activetransaction_delete", eventArgs);

    public async ValueTask RaiseActiveTransactionUpdateEventAsync(EventMessage<ActiveTransaction> eventArgs) =>
        await eventHub.RaiseEventAsync("activetransaction_update", eventArgs);
}