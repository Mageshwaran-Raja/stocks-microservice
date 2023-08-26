using CQRS.Core.Events;

namespace Stocks.Common.Events
{
    public class StockUpdatedEvent : BaseEvent
    {
        public StockUpdatedEvent() : base(nameof(StockUpdatedEvent)) { }
        public float TodaysHigh { get; set; }
        public float TodaysLow { get; set; }
        public float FiftyTwoWeekHigh { get; set; }
        public float FiftyTwoWeekLow { get; set; }
        public int Strength { get; set; }
        public int Weekness { get; set; }
        public int Opportunies { get; set; }
        public int Threads { get; set; }
        public int FinstarRating { get; set; }
        public int OwnershipRating { get; set; }
        public int EfficiencyRating { get; set; }
        public int ValuationRating { get; set; }
        public int FinancialsRating { get; set; }
        public float MarketCap { get; set; }
        public float EnterprisesValue { get; set; }
        public float NoOfShares { get; set; }
        public float DIVYield { get; set; }
        public float Cash { get; set; }
        public float PromoterHolding { get; set; }
        public DateTime StockUpdatedDate { get; set; }
    }
}
