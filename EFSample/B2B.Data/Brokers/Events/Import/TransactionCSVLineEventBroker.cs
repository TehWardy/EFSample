using B2B.Data.Brokers.Events.Import.Interfaces;
using B2B.Objects.Entities.Import;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Import;

public class TransactionCSVLineEventBroker : ITransactionCSVLineEventBroker
{
    private readonly IEventHub eventHub;

    public TransactionCSVLineEventBroker(IEventHub eventHub)
    {
        this.eventHub = eventHub;
    }

    public async ValueTask RaiseDeleteEventAsync(EventMessage<TransactionCSVLine> eventArgs) =>
        await eventHub.RaiseEventAsync("transactioncsvline_delete", eventArgs);

    public async ValueTask RaiseImportEventAsync(string transactionType, EventMessage<IEnumerable<TransactionCSVLine>> eventArgs) =>
        await eventHub.RaiseEventAsync($"csv{transactionType}_import", eventArgs);

    public async ValueTask RaiseImportEventsAsync(string transactionType, EventMessage<IEnumerable<TransactionCSVLine>[]> eventArgs) =>
        await eventHub.RaiseEventAsync($"csv{transactionType}_import", eventArgs);
}