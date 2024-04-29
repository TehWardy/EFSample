using B2B.Data.Brokers.Events.Payments.Interfaces;
using B2B.Objects.Entities.Payments;
using B2B.Objects.Entities.Transactions;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Payments;

public class EarlyDiscountPaymentEventBroker : IEarlyDiscountPaymentEventBroker
{
    private readonly IEventHub eventService;

    public EarlyDiscountPaymentEventBroker(IEventHub eventService) =>
        this.eventService = eventService;

    public async ValueTask RaiseEarlyDiscountPaidEventAsync(EventMessage<(RemittanceAdviceLine, Invoice)> eventArgs) =>
        await eventService.RaiseEventAsync("invoice_earlydiscountpaid", eventArgs);

    public async ValueTask RaiseEarlyDiscountPaidEventAsync(EventMessage<(RemittanceAdviceLine, Credit)> eventArgs) =>
        await eventService.RaiseEventAsync("credit_earlydiscountpaid", eventArgs);
}