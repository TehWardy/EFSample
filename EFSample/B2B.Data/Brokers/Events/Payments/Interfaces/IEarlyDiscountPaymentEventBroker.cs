using B2B.Objects.Entities.Payments;
using B2B.Objects.Entities.Transactions;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Payments.Interfaces;

public interface IEarlyDiscountPaymentEventBroker
{
    ValueTask RaiseEarlyDiscountPaidEventAsync(EventMessage<(RemittanceAdviceLine, Invoice)> eventArgs);
    ValueTask RaiseEarlyDiscountPaidEventAsync(EventMessage<(RemittanceAdviceLine, Credit)> eventArgs);
}