using System;

namespace Trader.Models
{
    public class OrderDTO
    {
        public string buySell { get; set; }
        public DateTime enteredWhen { get; set; }
        public string externalReference { get; set; }
        public decimal limitPrice { get; set; }
        public string market { get; set; }
        public string marketType { get; set; }
        public string orderRef { get; set; }
        public string orderType { get; set; }
        public decimal quantity { get; set; }
        public decimal quantityRemaining { get; set; }
        public string status { get; set; }
        public decimal stopPrice { get; set; }
        public string tradeType { get; set; }
    }
}