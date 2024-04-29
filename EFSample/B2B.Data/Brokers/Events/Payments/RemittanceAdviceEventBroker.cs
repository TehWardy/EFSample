using B2B.Data.Brokers.Events.Payments.Interfaces;
using B2B.Objects.Entities.Payments;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Payments;

public class RemittanceAdviceEventBroker : IRemittanceAdviceEventBroker
{
    private readonly IEventHub eventService;

    public RemittanceAdviceEventBroker(IEventHub eventService) =>
        this.eventService = eventService;

    public async ValueTask RaiseRemittanceAdviceAddEventAsync(EventMessage<RemittanceAdvice> eventArgs) =>
        await eventService.RaiseEventAsync("remittanceadvice_add", eventArgs);

    public async ValueTask RaiseRemittanceAdviceDeleteEventAsync(EventMessage<RemittanceAdvice> eventArgs) =>
        await eventService.RaiseEventAsync("remittanceadvice_delete", eventArgs);

    public async ValueTask RaiseRemittanceAdviceUpdateEventAsync(EventMessage<RemittanceAdvice> eventArgs) =>
        await eventService.RaiseEventAsync("remittanceadvice_update", eventArgs);
}