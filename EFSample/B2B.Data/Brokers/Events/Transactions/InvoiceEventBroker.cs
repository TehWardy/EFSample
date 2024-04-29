using B2B.Data.Brokers.Events.Transactions.Interfaces;
using B2B.Objects.Entities.Transactions;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Transactions;

public class InvoiceEventBroker : IInvoiceEventBroker
{
    private readonly IEventHub eventHub;

    public InvoiceEventBroker(IEventHub eventHub) =>
        this.eventHub = eventHub;

    public async ValueTask RaiseInvoiceAddEventAsync(EventMessage<Invoice> eventArgs) =>
        await eventHub.RaiseEventAsync("invoice_add", eventArgs);

    public async ValueTask RaiseInvoiceUpdateEventAsync(EventMessage<Invoice> eventArgs) =>
        await eventHub.RaiseEventAsync("invoice_update", eventArgs);

    public async ValueTask RaiseInvoiceDeleteEventAsync(EventMessage<Invoice> eventArgs) =>
        await eventHub.RaiseEventAsync("invoice_delete", eventArgs);
}