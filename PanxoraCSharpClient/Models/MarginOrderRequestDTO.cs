using System.Collections.Generic;

namespace PanxoraCSharpClient.Models
{
    public class MarginOrderRequestDTO
    {
        public List<string> buySell { get; set; }
        public string externalReference { get; set; }
        public decimal limitPrice { get; set; }
        public string market { get; set; }
        public string orderType { get; set; }
        public decimal quantity { get; set; }
        public decimal stopPrice { get; set; }
    }
}
