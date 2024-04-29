using B2B.Objects.Entities.Funding.Offer;
using EventLibrary.Objects;

namespace B2B.Data.Brokers.Events.Funding.Interfaces;

public interface IOfferEventBroker
{
    ValueTask RaiseOfferAddEventAsync(EventMessage<Offer> eventArgs);
    ValueTask RaiseBulkOfferAddEventAsync(EventMessage<IEnumerable<Offer>> message);
    ValueTask RaiseOfferDeleteEventAsync(EventMessage<Offer> eventArgs);
    ValueTask RaiseOfferDeleteEventsAsync(IEnumerable<EventMessage<Offer>> messages);
    ValueTask RaiseOfferUpdateEventAsync(EventMessage<Offer> eventArgs);
}