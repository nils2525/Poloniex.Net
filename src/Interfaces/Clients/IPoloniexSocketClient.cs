using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;

namespace Poloniex.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the CryptoCom websocket API
    /// </summary>
    public interface IPoloniexSocketClient : ISocketClient<HMACCredential>
    {

        /// <summary>
        /// Exchange API endpoints
        /// </summary>
        public IPoloniexSocketClientExchangeApi ExchangeApi { get; }
    }
}
