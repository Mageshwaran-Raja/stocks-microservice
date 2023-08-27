using CQRS.Core.Handlers;
using Stocks.Command.Domain.Aggregates;

namespace Stocks.Command.API.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IEventSourcingHandler<StocksAggregate> _eventSourcingHandler;
        public CommandHandler(IEventSourcingHandler<StocksAggregate> eventSourcingHandler)
        {
            _eventSourcingHandler = eventSourcingHandler;
        }

        public async Task HandleAsync(AddStocksCommand command)
        {
            var aggregate = new StocksAggregate();
            await _eventSourcingHandler.SaveAsync(aggregate);
        }

        public async Task HandleAsync(UpdateStocksCommand command)
        {
            var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
            aggregate.EditStock(command);
            await _eventSourcingHandler.SaveAsync(aggregate);
        }

        public async Task HandleAsync(UpdateStockViewerCountCommand command)
        {
            var aggreagte = await _eventSourcingHandler.GetByIdAsync(command.Id);
            aggreagte.StockViewerCountUpdate();

            await _eventSourcingHandler.SaveAsync(aggreagte);
        }
    }
}
