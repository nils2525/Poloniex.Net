using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange streams
    /// </summary>
    public interface IPoloniexSocketClientExchangeApi : ISocketApiClient, IDisposable
    {
        /// <summary>
        /// Subscribe to trade updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#trades" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PoloniexTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to trade updates for multiple symbols, or pass <c>all</c> as the sole symbol
        /// to subscribe to every market.
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/#subscribe" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<PoloniexTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to ticker updates for multiple symbols, or pass <c>all</c> as the sole symbol
        /// to subscribe to every market.
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#ticker" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToTickerUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<PoloniexTicker[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToCandleUpdatesAsync(string symbol, Action<DataEvent<PoloniexCandle[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<PoloniexOrderBook[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<PoloniexOrderUpdate[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to balance updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/balance" /></para>
        /// </summary>
        Task<WebSocketResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<PoloniexBalanceUpdate[]>> onMessage, CancellationToken ct = default);
    }
}
