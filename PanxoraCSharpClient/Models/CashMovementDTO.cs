using System;

namespace Trader.Models
{
    public class CashMovementDTO
    {
        public string currency { get; set; }
        public string description { get; set; }
        public DateTime enteredWhen { get; set; }
        public string positionRef { get; set; }
        public decimal quantity { get; set; }
        public string reference { get; set; }
        public Int64 transactionId { get; set; }
    }
}
