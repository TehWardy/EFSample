using B2B.Objects.Entities.Import;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Import.Interfaces;

public interface ITransactionCSVLineEventBroker
{
    ValueTask RaiseDeleteEventAsync(EventMessage<TransactionCSVLine> eventArgs);
    ValueTask RaiseImportEventAsync(string transactionType, EventMessage<IEnumerable<TransactionCSVLine>> eventArgs);
    ValueTask RaiseImportEventsAsync(string transactionType, EventMessage<IEnumerable<TransactionCSVLine>[]> eventArgs);
}