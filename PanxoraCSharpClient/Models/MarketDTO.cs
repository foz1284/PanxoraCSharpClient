namespace PanxoraCSharpClient.Models
{
    public class MarketDTO
    {
        public string baseCurrency { get; set; }
        public bool cashTradeable { get; set; }
        public string exchange { get; set; }
        public string floatCurrency { get; set; }
        public bool marginTradeable { get; set; }
        public string market { get; set; }
        public string name { get; set; }
        public decimal priceMakeFeeAmount { get; set; }
        public string priceMarkerFeeType { get; set; }
        public int priceRounding { get; set; }
        public decimal proceTakerFeeAmount { get; set; }
        public string priceTakerFeeType { get; set; }
        public int quantityRounding { get; set; }
        public string sector { get; set; }
    }
}
