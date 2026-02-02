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
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PoloniexTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToCandleUpdatesAsync(string symbol, Action<DataEvent<PoloniexCandle[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<PoloniexOrderBook[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to candle updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/market-data#candlesticks" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<PoloniexOrderUpdate[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to balance updates
        /// <para><a href="https://api-docs.poloniex.com/spot/websocket/balance" /></para>
        /// </summary>
        Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<PoloniexBalanceUpdate[]>> onMessage, CancellationToken ct = default);
    }
}
