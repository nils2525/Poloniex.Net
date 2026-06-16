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
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PoloniexFuturesTrade[]>> onMessage, CancellationToken ct = default);

        /// <summary>
        /// Subscribe to futures trade updates.
        /// </summary>
        /// <param name="symbols">Symbols</param>
        /// <param name="onMessage">Update handler</param>
        /// <param name="ct">Cancellation token</param>
        Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<PoloniexFuturesTrade[]>> onMessage, CancellationToken ct = default);
    }
}
