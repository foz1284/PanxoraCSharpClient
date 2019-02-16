namespace Trader.Models
{
    public class MarginPositionDTO
    {
        public decimal averagePrice { get; set; }
        public decimal costAndIncome { get; set; }
        public string market { get; set; }
        public decimal marketPrice { get; set; }
        public string positionRef { get; set; }
        public decimal quantity { get; set; }
        public string status { get; set; }
        public decimal stopLevel { get; set; }
        public decimal sweptBtc { get; set; }
        public decimal totalPnl { get; set; }
        public decimal totalPnlBtc { get; set; }
        public decimal unsweptPnl { get; set; }
    }
}
