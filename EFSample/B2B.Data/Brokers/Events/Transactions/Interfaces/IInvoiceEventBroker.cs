using B2B.Objects.Entities.Transactions;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Transactions.Interfaces;

public interface IInvoiceEventBroker
{
    ValueTask RaiseInvoiceAddEventAsync(EventMessage<Invoice> eventArgs);
    ValueTask RaiseInvoiceUpdateEventAsync(EventMessage<Invoice> eventArgs);
    ValueTask RaiseInvoiceDeleteEventAsync(EventMessage<Invoice> eventArgs);
}
