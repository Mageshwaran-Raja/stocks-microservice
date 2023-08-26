using CQRS.Core.Events;

namespace Stocks.Common.Events
{
    public class StockViewerCountUpdatedEvent : BaseEvent
    {
        public StockViewerCountUpdatedEvent() : base(nameof(StockViewerCountUpdatedEvent)) { }
    }
}
