using Newtonsoft.Json;
using PanxoraCSharpClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PanxoraCSharpClient
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
        

        public AccountSummaryDTO GetAccountSummary()
        {
            var request = new RestRequest("account-summary", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<AccountSummaryDTO>(response.Content);
        }

        public CashMovementDTO ListCashMovements(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("cash-movements", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<CashMovementDTO>(response.Content);
        }

        public List<CashBalanceDTO> GetCashBalances()
        {
            var request = new RestRequest("cash-balances", Method.GET);
            request.AddHeader(APIKeyParameterName, APIKey);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<CashBalanceDTO>>(response.Content);
        }
        
        public IEnumerable<OrderDTO> ListCashOrders(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("cash-orders", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<OrderDTO>>(response.Content);
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

        public void DeleteCashOrder(string orderRef)
        {
            var request = new RestRequest("cash-orders/" + orderRef, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("orderRef", orderRef);

            IRestResponse response = client.Execute(request);

            return;
        }
        
        public IEnumerable<TradeDTO> GetTrades()
        {
            var request = new RestRequest("cash-trades", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TradeDTO>>(response.Content);
        }

        public TradeDTO GetTrade(string tradeRef)
        {
            var request = new RestRequest("cash-trades/" + tradeRef, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("tradeRef ", tradeRef);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<TradeDTO>(response.Content);
        }

        public IEnumerable<OrderDTO> ListMarginOrders(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("margin-orders", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<OrderDTO>>(response.Content);
        }

        public OrderDTO CreateMarginOrder(MarginOrderRequestDTO marginOrderRequest)
        {
            var request = new RestRequest("cash-orders", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddJsonBody(JsonConvert.SerializeObject(marginOrderRequest));
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<OrderDTO>(response.Content);
        }

        public OrderDTO GetMarginOrder(string orderRef)
        {
            var request = new RestRequest("margin-orders/" + orderRef, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("orderRef", orderRef);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<OrderDTO>(response.Content);
        }

        public void DeleteMarginOrder(string orderRef)
        {
            var request = new RestRequest("margin-orders/" + orderRef, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("orderRef", orderRef);

            IRestResponse response = client.Execute(request);

            return;
        }

        public IEnumerable<MarginPositionDTO> ListMarginPositions()
        {
            var request = new RestRequest("margin-positions", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
        
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<MarginPositionDTO>>(response.Content);
        }

        public IEnumerable<TradeDTO> ListMarginTrades(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("margin-trades", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TradeDTO>>(response.Content);
        }

        public TradeDTO GetMarginTrade(string tradeRef)
        {
            var request = new RestRequest("margin-trades/" + tradeRef, Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("tradeRef", tradeRef);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<TradeDTO>(response.Content);
        }

        public IEnumerable<MarketDTO> ListMarkets()
        {
            var request = new RestRequest("markets", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<MarketDTO>>(response.Content);
        }

        public MarketDTO GetMarketDetails(string market)
        {
            var request = new RestRequest(string.Format("markets/{0}", market), Method.GET);
            request.AddHeader(APIKeyParameterName, APIKey);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<MarketDTO>(response.Content);
        }

        public IEnumerable<MarketDTO> ListMarketChartData(string market, DateTime? startDate, DateTime? endDate, string aggregationLevel, int? rows)
        {
            var request = new RestRequest(string.Format("markets/{0}/chart-data", market), Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            request.AddHeader("aggregationLevel", aggregationLevel);
            if (rows != null)
            {
                request.AddHeader("rows", rows.Value.ToString());
            }

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<MarketDTO>>(response.Content);
        }

        public IEnumerable<MarketDepthDTO> ListMarketDepth(string market)
        {
            var request = new RestRequest(string.Format("markets/{0}/depth", market), Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<MarketDepthDTO>>(response.Content);
        }

        public PricingDTO GetMarketPrices(string market)
        {
            var request = new RestRequest(string.Format("markets/{0}/prices", market), Method.GET);
            request.AddHeader(APIKeyParameterName, APIKey);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<PricingDTO>(response.Content);
        }

        public IEnumerable<TradeHistoryDTO> ListTradeHistory(string market, DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest(string.Format("trade-history/{0}", market), Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TradeHistoryDTO>>(response.Content);
        }

        public IEnumerable<TradeHistoryDTO> ListTimeSales(string market)
        {
            var request = new RestRequest(string.Format("trade-history/{0}/time-sales", market), Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<TradeHistoryDTO>>(response.Content);
        }

        public IEnumerable<WatchlistDTO> ListWatchLists()
        {
            var request = new RestRequest("watchlists", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<WatchlistDTO>>(response.Content);
        }

        public IEnumerable<PricingDTO> ListGlobalWatchListPrices(string globalWatchlistName)
        {
            var request = new RestRequest(string.Format("watchlists/{0}", globalWatchlistName), Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("globalWatchlistName  ", globalWatchlistName);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<PricingDTO>>(response.Content);
        }

        public IEnumerable<PricingDTO> ListWatchListPrices(string watchlistName)
        {
            var request = new RestRequest(string.Format("watchlists/{0}", watchlistName), Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("watchlistName ", watchlistName);

            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<IEnumerable<PricingDTO>>(response.Content);
        }

        public void DeleteUserWatchList(string watchlistName)
        {
            var request = new RestRequest(string.Format("watchlists/{0}", watchlistName), Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader(APIKeyParameterName, APIKey);
            request.AddHeader("watchlistName ", watchlistName);

            IRestResponse response = client.Execute(request);

            return;
        }
    }
}
