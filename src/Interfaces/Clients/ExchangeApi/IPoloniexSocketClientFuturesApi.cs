using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Poloniex futures websocket API endpoints.
    /// </summary>
    public interface IPoloniexSocketClientFuturesApi
    {
        /// <summary>
        /// Subscribe to futures trade updates.
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="onMessage">Update handler</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PoloniexFuturesTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to futures trade updates.
        /// </summary>
        /// <param name="symbols">Symbols</param>
        /// <param name="onMessage">Update handler</param>
        /// <param name="ct">Cancellation token</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<PoloniexFuturesTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to futures 24-hour ticker updates.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/websocket/public/get-trading-info" /></para>
        /// </summary>
        /// <param name="symbols">Symbols, or <c>all</c> for the all-symbol wildcard.</param>
        /// <param name="onMessage">Update handler.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<PoloniexFuturesTicker[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to futures index-price updates.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/websocket/public/get-index-price" /></para>
        /// </summary>
        /// <param name="symbols">Symbols to subscribe to. The live endpoint rejects the <c>all</c> wildcard for this channel.</param>
        /// <param name="onMessage">Update handler.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToIndexPriceUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<PoloniexFuturesIndexPrice[]>> onMessage, CancellationToken ct = default);

        /// <summary>Subscribe to predicted futures funding-rate updates.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/websocket/public/get-funding-rate" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToFundingRateUpdatesAsync(IEnumerable<string> symbols,
            Action<DataEvent<PoloniexFuturesFundingRate[]>> onMessage, CancellationToken ct = default);

        /// <summary>Subscribe to private futures order updates.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/websocket/private/orders" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(IEnumerable<string> symbols,
            Action<DataEvent<PoloniexFuturesOrder[]>> onMessage, CancellationToken ct = default);

        /// <summary>Subscribe to private futures position updates.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/websocket/private/positions" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToPositionUpdatesAsync(IEnumerable<string> symbols,
            Action<DataEvent<PoloniexFuturesPosition[]>> onMessage, CancellationToken ct = default);

        /// <summary>Subscribe to private futures execution updates.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/websocket/private/trade" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToUserTradeUpdatesAsync(IEnumerable<string> symbols,
            Action<DataEvent<PoloniexFuturesOrderTrade[]>> onMessage, CancellationToken ct = default);
    }
}
