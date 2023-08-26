﻿using CQRS.Core.Commands;

namespace Stocks.Command.API.Commands
{
    public class AddStocksCommand : BaseCommand
    {
        public string Title { get; set; }
        public string NSE { get; set; }
        public string BSE { get; set; }
        public string Section { get; set; }
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
        public int ViewerCount { get; set; }
    }
}
