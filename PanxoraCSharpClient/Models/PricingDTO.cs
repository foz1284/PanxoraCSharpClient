namespace Trader.Models
{
    public class PricingDTO
    {
        public decimal askPrice { get; set; }
        public string askPriceTickDirection { get; set; }
        public decimal bidPrice { get; set; }
        public string bidPriceTickDirection { get; set; }
        public string environmentGroup { get; set; }
        public decimal highPrice { get; set; }
        public decimal lastPrice { get; set; }
        public string lastPriceTickDirection { get; set; }
        public decimal lowPrice { get; set; }
        public string market { get; set; }
        public decimal openPrice { get; set; }
        public decimal prevDayClose { get; set; }
    }
}
