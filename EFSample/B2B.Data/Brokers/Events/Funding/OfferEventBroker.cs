using B2B.Data.Brokers.Events.Funding.Interfaces;
using B2B.Objects.Entities.Funding.Offer;
using EventLibrary;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Funding;

public class OfferEventBroker : IOfferEventBroker
{
    private readonly IEventHub eventHub;

    public OfferEventBroker(IEventHub eventHub) =>
        this.eventHub = eventHub;

    public async ValueTask RaiseOfferAddEventAsync(EventMessage<Offer> message) =>
        await eventHub.RaiseEventAsync("offer_add", message);

    public async ValueTask RaiseBulkOfferAddEventAsync(EventMessage<IEnumerable<Offer>> message) =>
        await eventHub.RaiseEventAsync("bulk_offer_add", message);

    public async ValueTask RaiseOfferDeleteEventAsync(EventMessage<Offer> message) =>
        await eventHub.RaiseEventAsync("offer_delete", message);

    public ValueTask RaiseOfferDeleteEventsAsync(IEnumerable<EventMessage<Offer>> messages) =>
        eventHub.RaiseEventsAsync("offer_delete", messages.ToArray());

    public async ValueTask RaiseOfferUpdateEventAsync(EventMessage<Offer> message) =>
        await eventHub.RaiseEventAsync("offer_update", message);
}