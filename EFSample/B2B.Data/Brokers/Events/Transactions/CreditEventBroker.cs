using B2B.Data.Brokers.Events.Transactions.Interfaces;
using B2B.Objects.Entities.Transactions;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Transactions;

public class CreditEventBroker : ICreditEventBroker
{
    private readonly IEventHub eventHub;

    public CreditEventBroker(IEventHub eventHub) =>
        this.eventHub = eventHub;

    public async ValueTask RaiseCreditAddEventAsync(EventMessage<Credit> eventArgs) =>
        await eventHub.RaiseEventAsync("credit_add", eventArgs);

    public async ValueTask RaiseCreditDeleteEventAsync(EventMessage<Credit> eventArgs) =>
        await eventHub.RaiseEventAsync("credit_delete", eventArgs);

    public async ValueTask RaiseCreditUpdateEventAsync(EventMessage<Credit> eventArgs) =>
        await eventHub.RaiseEventAsync("credit_update", eventArgs);
}