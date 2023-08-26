using CQRS.Core.Domain;
using Stocks.Common.DTOs;
using Stocks.Common.Events;

namespace Stocks.Command.Domain.Aggregates
{
    public class StocksAggregate : AggregateRoot
    {
        private bool _active;
        public bool Active
        {
            get => _active; set => _active = value;
        }

        public StocksAggregate() { }

        // Create a new Stock Created Event
        public StocksAggregate(CreateStockDTO createStockDTO)
        {
            RaiseEvent(new StockCreatedEvent
            {
                Title = createStockDTO.Title,
                NSE = createStockDTO.NSE,
                BSE = createStockDTO.BSE,
                Section = createStockDTO.Section,   
                TodaysHigh = createStockDTO.TodaysHigh,
                TodaysLow = createStockDTO.TodaysLow,
                FiftyTwoWeekHigh = createStockDTO.FiftyTwoWeekHigh,
                FiftyTwoWeekLow = createStockDTO.FiftyTwoWeekLow,
                Strength = createStockDTO.Strength,
                Weekness = createStockDTO.Weekness,
                Opportunies = createStockDTO.Opportunies,
                Threads = createStockDTO.Threads,
                FinancialsRating = createStockDTO.FinancialsRating,
                OwnershipRating = createStockDTO.OwnershipRating,
                EfficiencyRating = createStockDTO.EfficiencyRating,
                ValuationRating = createStockDTO.ValuationRating,
                EnterprisesValue = createStockDTO.EnterprisesValue,
                MarketCap = createStockDTO.MarketCap,
                NoOfShares = createStockDTO.NoOfShares,
                DIVYield = createStockDTO.DIVYield,
                Cash = createStockDTO.Cash,
                PromoterHolding = createStockDTO.PromoterHolding,
                ViewerCount = createStockDTO.ViewerCount,
                StockCreatedDate = DateTime.Now
            });
        }

        public void Apply(StockCreatedEvent @event)
        {
            _id = @event.Id;
            _active = true;
        }

        // Edit Stock Event
        public void EditStock(UpdateStockDTO updateStockDTO)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot edit the message of inactive post");
            }

            RaiseEvent(new StockUpdatedEvent
            {
                Id = _id,
                TodaysHigh = updateStockDTO.TodaysHigh,
                TodaysLow = updateStockDTO.TodaysLow,
                FiftyTwoWeekHigh = updateStockDTO.FiftyTwoWeekHigh,
                FiftyTwoWeekLow = updateStockDTO.FiftyTwoWeekLow,
                Strength = updateStockDTO.Strength,
                Weekness = updateStockDTO.Weekness,
                Opportunies = updateStockDTO.Opportunies,
                Threads = updateStockDTO.Threads,
                FinancialsRating = updateStockDTO.FinancialsRating,
                OwnershipRating = updateStockDTO.OwnershipRating,
                EfficiencyRating = updateStockDTO.EfficiencyRating,
                ValuationRating = updateStockDTO.ValuationRating,
                EnterprisesValue = updateStockDTO.EnterprisesValue,
                MarketCap = updateStockDTO.MarketCap,
                NoOfShares = updateStockDTO.NoOfShares,
                DIVYield = updateStockDTO.DIVYield,
                Cash = updateStockDTO.Cash,
                PromoterHolding = updateStockDTO.PromoterHolding,
                StockUpdatedDate = DateTime.Now
            });
        }

        public void Apply(StockUpdatedEvent @event)
        {
            _id = @event.Id;
        }

        // Update the Viewer Count Event
        public void StockViewerCountUpdate()
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot live inactive post");
            }

            RaiseEvent(new StockViewerCountUpdatedEvent
            {
                Id = _id
            });
        }

        public void Apply(StockViewerCountUpdatedEvent @event)
        {
            _id = @event.Id;
        }
    }
}
