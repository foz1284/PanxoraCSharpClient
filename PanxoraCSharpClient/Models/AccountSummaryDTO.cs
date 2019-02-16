namespace Trader.Models
{
    public class AccountSummaryDTO
    {
        public decimal availableMargin { get; set; }
        public decimal cash { get; set; }
        public decimal profit { get; set; }
        public decimal totalAccountValue { get; set; }
        public decimal totalMargin { get; set; }
    }
}
