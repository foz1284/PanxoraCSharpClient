namespace PanxoraCSharpClient.Models
{
    public class CashBalanceDTO
    {
        public decimal availableToWithdraw { get; set; }
        public decimal balance { get; set; }
        public decimal balanceBtc { get; set; }
        public string currency { get; set; }
    }
}
