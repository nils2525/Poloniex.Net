using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>Poloniex futures trading and position endpoints.</summary>
    public interface IPoloniexRestClientFuturesApiTrading
    {
        /// <summary>Place a futures order.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/trade/place-order" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesOrderId>> PlaceOrderAsync(string symbol, PoloniexTradeSide side,
            PoloniexFuturesMarginMode marginMode, PoloniexFuturesPositionSide positionSide,
            PoloniexOrderType type, decimal quantity, decimal? price = null, string? clientOrderId = null,
            bool? reduceOnly = null, PoloniexOrderTimeInForce? timeInForce = null, CancellationToken ct = default);

        /// <summary>Cancel a futures order.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/trade/cancel-order" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesOrderId>> CancelOrderAsync(string symbol, string? orderId = null,
            string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>Get open futures orders.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/trade/get-current-orders" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesOrder[]>> GetOpenOrdersAsync(string? symbol = null, string? orderId = null,
            string? clientOrderId = null, string? from = null, int? limit = null,
            PoloniexPageDirection? direction = null, CancellationToken ct = default);

        /// <summary>Get one current or historical futures order.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/trade/get-order-details" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesOrder>> GetOrderAsync(string? orderId = null,
            string? clientOrderId = null, CancellationToken ct = default);

        /// <summary>Get futures order executions.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/trade/get-execution-details" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesOrderTrade[]>> GetOrderTradesAsync(string? symbol = null,
            string? orderId = null, string? clientOrderId = null, string? from = null, int? limit = null,
            PoloniexPageDirection? direction = null, CancellationToken ct = default);

        /// <summary>Get current futures positions.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/positions/get-current-position" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesPosition[]>> GetOpenPositionsAsync(string? symbol = null,
            CancellationToken ct = default);

        /// <summary>Close a futures position at market.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/trade/close-at-market-price" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesOrderId>> ClosePositionAsync(string symbol,
            PoloniexFuturesMarginMode marginMode, PoloniexFuturesPositionSide? positionSide = null,
            string? clientOrderId = null, CancellationToken ct = default);
    }
}
