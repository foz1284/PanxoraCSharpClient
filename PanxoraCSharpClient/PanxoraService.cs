using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using Trader.Models;

namespace Trader
{
    public class PanxoraService
    {
        private RestClient client;
        private string APIKey;
        private string APIKeyParameterName = "X-PANXORA-API-KEY";

        public PanxoraService(string rootURL, string apiKey)
        {
            client = new RestClient(rootURL);
            APIKey = apiKey;
        }

        public List<CashBalanceDTO> GetCashBalances()
        {
            var request = new RestRequest("cash-balances", Method.GET);
            request.AddHeader(APIKeyParameterName, APIKey);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<CashBalanceDTO>>(response.Content);
        }

        internal PricingDTO GetMarketDetails(string market)
        {
            var request = new RestRequest(string.Format("markets/{0}/prices", market), Method.GET);
            request.AddHeader(APIKeyParameterName, APIKey);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<PricingDTO>(response.Content);
        }

        public OrderDTO CreateSellCashOrder(decimal quantity)
        {
            var cashOrderRequest = new CashOrderRequest
            {
                buySell = "SELL",
                externalReference = "string",
                limitPrice = 1,
                market = "BTCUSD",
                orderType = "LIMIT",
                quantity = quantity
            };

            return CreateCashOrder(cashOrderRequest);
        }

        public OrderDTO CreateBuyCashOrder(decimal limitPrice, decimal quantity)
        {
            var cashOrderRequest = new CashOrderRequest
            {
                buySell = "BUY",
                externalReference = "string",
                limitPrice = limitPrice,
                market = "BTCUSD",
                orderType = "LIMIT",
                quantity = quantity
            };

            return CreateCashOrder(cashOrderRequest);
        }

        public OrderDTO CreateCashOrder(CashOrderRequest cashOrderRequest)
        {
            var request = new RestRequest("cash-orders", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddJsonBody(JsonConvert.SerializeObject(cashOrderRequest));
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<OrderDTO>(response.Content);
        }

        public OrderDTO GetCashOrder(string orderRef)
        {
            var request = new RestRequest("cash-orders/" + orderRef, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("orderRef", orderRef);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<OrderDTO>(response.Content);
        }

        public IEnumerable<TradeDTO> GetTrades()
        {
            var request = new RestRequest("cash-trades", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TradeDTO>>(response.Content);
        }
    }
}
