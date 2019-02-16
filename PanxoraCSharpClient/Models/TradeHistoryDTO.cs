using System;

namespace Trader.Models
{
    public class TradeHistoryDTO
    {
        public Int64 id { get; set; }
        public string market { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public DateTime timestamp { get; set; }
    }
}
