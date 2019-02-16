using System;

namespace Trader.Models
{
    public class TradeDTO
    {
        public string buySell { get; set; }
        public DateTime enteredWhen { get; set; }
        public string market { get; set; }
        public string marketLongName { get; set; }
        public string marketType { get; set; }
        public string orderRef { get; set; }
        public decimal quantity { get; set; }
        public decimal tradePrice { get; set; }
        public string tradeRef { get; set; }
        public string tradeType { get; set; }
    }
}