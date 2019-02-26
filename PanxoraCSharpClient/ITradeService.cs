using System;
using System.Collections.Generic;
using PanxoraCSharpClient.Models;

namespace PanxoraCSharpClient
{
    public interface ITradeService
    {
        OrderDTO CreateCashOrder(CashOrderRequest cashOrderRequest);
        OrderDTO CreateMarginOrder(MarginOrderRequestDTO marginOrderRequest);
        void DeleteCashOrder(string orderRef);
        void DeleteMarginOrder(string orderRef);
        void DeleteUserWatchList(string watchlistName);
        AccountSummaryDTO GetAccountSummary();
        IEnumerable<CashBalanceDTO> GetCashBalances();
        OrderDTO GetCashOrder(string orderRef);
        OrderDTO GetMarginOrder(string orderRef);
        TradeDTO GetMarginTrade(string tradeRef);
        MarketDTO GetMarketDetails(string market);
        PricingDTO GetMarketPrices(string market);
        TradeDTO GetTrade(string tradeRef);
        IEnumerable<TradeDTO> GetTrades();
        CashMovementDTO ListCashMovements(DateTime? startDate, DateTime? endDate);
        IEnumerable<OrderDTO> ListCashOrders(DateTime? startDate, DateTime? endDate);
        IEnumerable<PricingDTO> ListGlobalWatchListPrices(string globalWatchlistName);
        IEnumerable<OrderDTO> ListMarginOrders(DateTime? startDate, DateTime? endDate);
        IEnumerable<MarginPositionDTO> ListMarginPositions();
        IEnumerable<TradeDTO> ListMarginTrades(DateTime? startDate, DateTime? endDate);
        IEnumerable<MarketDTO> ListMarketChartData(string market, DateTime? startDate, DateTime? endDate, string aggregationLevel, int? rows);
        IEnumerable<MarketDepthDTO> ListMarketDepth(string market);
        IEnumerable<MarketDTO> ListMarkets();
        IEnumerable<TradeHistoryDTO> ListTimeSales(string market);
        IEnumerable<TradeHistoryDTO> ListTradeHistory(string market, DateTime? startDate, DateTime? endDate);
        IEnumerable<PricingDTO> ListWatchListPrices(string watchlistName);
        IEnumerable<WatchlistDTO> ListWatchLists();
    }
}