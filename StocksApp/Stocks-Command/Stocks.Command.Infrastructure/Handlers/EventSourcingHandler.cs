using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructure;
using Stocks.Command.Domain.Aggregates;

namespace Stocks.Command.Infrastructure.Handlers
{
    public class EventSourcingHandler : IEventSourcingHandler<StocksAggregate>
    {
        private readonly IEventStore _eventStore;
        public EventSourcingHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task<StocksAggregate> GetByIdAsync(Guid aggregateId)
        {
            var aggregate = new StocksAggregate();
            var events = await _eventStore.GetEventsAsync(aggregateId);

            if (events == null || !events.Any()) return aggregate;

            aggregate.ReplayEvents(events);
            aggregate.Version = events.Select(x => x.Version).Max();

            return aggregate;
        }

        public async Task SaveAsync(AggregateRoot aggregate)
        {
            await _eventStore.SaveEventAsync(aggregate.Id, aggregate.GetUncommitedChanges(), 
                aggregate.Version);
            aggregate.MarkChangesAsCommited();
        }
    }
}
