using B2B.Objects.Entities.Payments;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Payments.Interfaces;

public interface IRemittanceAdviceEventBroker
{
    ValueTask RaiseRemittanceAdviceAddEventAsync(EventMessage<RemittanceAdvice> eventArgs);
    ValueTask RaiseRemittanceAdviceUpdateEventAsync(EventMessage<RemittanceAdvice> eventArgs);
    ValueTask RaiseRemittanceAdviceDeleteEventAsync(EventMessage<RemittanceAdvice> eventArgs);
}

