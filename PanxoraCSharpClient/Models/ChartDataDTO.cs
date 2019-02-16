using System;

namespace Trader.Models
{
    public class ChartDataDTO
    {
        public decimal closePrice { get; set; }
        public decimal highPrice { get; set; }
        public decimal lowPrice { get; set; }
        public decimal openPrice { get; set; }
        public DateTime period { get; set; }
        public Int64 volume { get; set; }
    }
}
