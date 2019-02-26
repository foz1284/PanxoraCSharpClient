using Newtonsoft.Json;
using PanxoraCSharpClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PanxoraCSharpClient
{
    public class PanxoraService : ITradeService
    {
        readonly IRestClient client;
        private string APIKey;
        private string APIKeyParameterName = "X-PANXORA-API-KEY";

        private IAudit audit;
        public PanxoraService(string rootURL, string apiKey, IAudit audit)
        {
            client = new RestClient(rootURL);
            APIKey = apiKey;

            this.audit = audit;
        }

        private T Execute<T>(RestRequest request) where T : new()
        {
            request.AddHeader(APIKeyParameterName, APIKey);
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK &&
                response.StatusCode != System.Net.HttpStatusCode.Created
                )
            {
                string message = "Status Code:" + response.StatusCode.ToString() + Environment.NewLine + response.Content;
                throw new ApplicationException(message);
            }

            return response.Data;
        }

        public AccountSummaryDTO GetAccountSummary()
        {
            var request = new RestRequest("account-summary", Method.GET);
            
            return Execute<AccountSummaryDTO>(request);
        }

        public CashMovementDTO ListCashMovements(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("cash-movements", Method.GET);
 
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            return Execute<CashMovementDTO>(request);
        }

        public IEnumerable<CashBalanceDTO> GetCashBalances()
        {
            var request = new RestRequest("cash-balances", Method.GET);

            return Execute<List<CashBalanceDTO>>(request);
        }
        
        public IEnumerable<OrderDTO> ListCashOrders(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("cash-orders", Method.GET);

            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            return Execute<List<OrderDTO>>(request);
        }

        public OrderDTO CreateCashOrder(CashOrderRequest cashOrderRequest)
        {
            audit.Log("CreateCashOrder", cashOrderRequest);
            var request = new RestRequest("cash-orders", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(cashOrderRequest));

            return Execute<OrderDTO>(request);
        }

        public OrderDTO GetCashOrder(string orderRef)
        {
            var request = new RestRequest("cash-orders/" + orderRef, Method.GET);
            request.AddHeader("orderRef", orderRef);

            return Execute<OrderDTO>(request);
        }

        public void DeleteCashOrder(string orderRef)
        {
            audit.Log("DeleteCashOrder", orderRef);
            var request = new RestRequest("cash-orders/" + orderRef, Method.DELETE);
            request.AddHeader("orderRef", orderRef);

            Execute<object>(request);

            return;
        }
        
        public IEnumerable<TradeDTO> GetTrades()
        {
            var request = new RestRequest("cash-trades", Method.GET);

            return Execute<List<TradeDTO>>(request);
        }

        public TradeDTO GetTrade(string tradeRef)
        {
            var request = new RestRequest("cash-trades/" + tradeRef, Method.GET);
            request.AddHeader("tradeRef ", tradeRef);

            return Execute<TradeDTO>(request);
        }

        public IEnumerable<OrderDTO> ListMarginOrders(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("margin-orders", Method.GET);

            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            return Execute<List<OrderDTO>>(request);
        }

        public OrderDTO CreateMarginOrder(MarginOrderRequestDTO marginOrderRequest)
        {
            audit.Log("CreateMarginOrder", marginOrderRequest);
            var request = new RestRequest("cash-orders", Method.POST);
            request.AddJsonBody(JsonConvert.SerializeObject(marginOrderRequest));

            return Execute<OrderDTO>(request);
        }

        public OrderDTO GetMarginOrder(string orderRef)
        {
            var request = new RestRequest("margin-orders/" + orderRef, Method.GET);
            request.AddHeader("orderRef", orderRef);

            return Execute<OrderDTO>(request);
        }

        public void DeleteMarginOrder(string orderRef)
        {
            audit.Log("DeleteMarginOrder", orderRef);
            var request = new RestRequest("margin-orders/" + orderRef, Method.DELETE);
            request.AddHeader("orderRef", orderRef);

            Execute<object>(request);

            return;
        }

        public IEnumerable<MarginPositionDTO> ListMarginPositions()
        {
            var request = new RestRequest("margin-positions", Method.GET);
        
            return Execute<List<MarginPositionDTO>>(request);
        }

        public IEnumerable<TradeDTO> ListMarginTrades(DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest("margin-trades", Method.GET);
            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            return Execute<List<TradeDTO>>(request);
        }

        public TradeDTO GetMarginTrade(string tradeRef)
        {
            var request = new RestRequest("margin-trades/" + tradeRef, Method.GET);
            request.AddHeader("tradeRef", tradeRef);

            return Execute<TradeDTO>(request);
        }

        public IEnumerable<MarketDTO> ListMarkets()
        {
            var request = new RestRequest("markets", Method.GET);

            return Execute<List<MarketDTO>>(request);
        }

        public MarketDTO GetMarketDetails(string market)
        {
            var request = new RestRequest(string.Format("markets/{0}", market), Method.GET);

            return Execute<MarketDTO>(request);
        }

        public IEnumerable<MarketDTO> ListMarketChartData(string market, DateTime? startDate, DateTime? endDate, string aggregationLevel, int? rows)
        {
            var request = new RestRequest(string.Format("markets/{0}/chart-data", market), Method.GET);

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

            return Execute<List<MarketDTO>>(request);
        }

        public IEnumerable<MarketDepthDTO> ListMarketDepth(string market)
        {
            var request = new RestRequest(string.Format("markets/{0}/depth", market), Method.GET);

            return Execute<List<MarketDepthDTO>>(request);
        }

        public PricingDTO GetMarketPrices(string market)
        {
            var request = new RestRequest(string.Format("markets/{0}/prices", market), Method.GET);

            return Execute<PricingDTO>(request);
        }

        public IEnumerable<TradeHistoryDTO> ListTradeHistory(string market, DateTime? startDate, DateTime? endDate)
        {
            var request = new RestRequest(string.Format("trade-history/{0}", market), Method.GET);

            if (startDate != null)
            {
                request.AddHeader("start", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            if (endDate != null)
            {
                request.AddHeader("end", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
            }

            return Execute<List<TradeHistoryDTO>>(request);
        }

        public IEnumerable<TradeHistoryDTO> ListTimeSales(string market)
        {
            var request = new RestRequest(string.Format("trade-history/{0}/time-sales", market), Method.GET);

            return Execute<List<TradeHistoryDTO>>(request);
        }

        public IEnumerable<WatchlistDTO> ListWatchLists()
        {
            var request = new RestRequest("watchlists", Method.GET);

            return Execute<List<WatchlistDTO>>(request);
        }

        public IEnumerable<PricingDTO> ListGlobalWatchListPrices(string globalWatchlistName)
        {
            var request = new RestRequest(string.Format("watchlists/{0}", globalWatchlistName), Method.GET);
            request.AddHeader("globalWatchlistName  ", globalWatchlistName);

            return Execute<List<PricingDTO>>(request);
        }

        public IEnumerable<PricingDTO> ListWatchListPrices(string watchlistName)
        {
            var request = new RestRequest(string.Format("watchlists/{0}", watchlistName), Method.GET);
            request.AddHeader("watchlistName ", watchlistName);

            return Execute<List<PricingDTO>>(request);
        }

        public void DeleteUserWatchList(string watchlistName)
        {
            audit.Log("DeleteUserWatchList", watchlistName);
            var request = new RestRequest(string.Format("watchlists/{0}", watchlistName), Method.DELETE);
            request.AddHeader("watchlistName ", watchlistName);

            Execute<object>(request);

            return;
        }
    }
}
