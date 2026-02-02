using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange trading endpoints, placing and managing orders.
    /// </summary>
    public interface IPoloniexRestClientExchangeApiTrading
    {
        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/order" />
        /// </summary>
        Task<WebCallResult<PoloniexOrderId>> PlaceOrderAsync(string symbol, PoloniexTradeSide side, PoloniexOrderType type, decimal price, decimal quantity, string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/order#cancel-order-by-id" />
        /// </summary>
        Task<WebCallResult<PoloniexCancelOrderResult>> CancelOrderAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/order#open-orders" />
        /// </summary>
        Task<WebCallResult<PoloniexOrder[]>> GetOpenOrdersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/order#order-details" />
        /// </summary>
        Task<WebCallResult<PoloniexOrder>> GetOrderByIdAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/trade#trades-by-order-id" />
        /// </summary>
        Task<WebCallResult<PoloniexOrderTrade[]>> GetOrderTradesAsync(string orderId, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/trade#trade-history" />
        /// </summary>
        Task<WebCallResult<PoloniexOrderTrade[]>> GetOrderTradeHistoryAsync(int? limit = null, DateTime? startTime = null, DateTime? endTime = null, long? from = null, PoloniexPageDirection? pageDirection = null, string[]? symbols = null, CancellationToken ct = default);
    }
}
