using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;
using CryptoExchange.Net.Objects.Options;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;

namespace Poloniex.Net.Interfaces.Clients
{
    /// <summary>
    /// Client for accessing the CryptoCom Rest API. 
    /// </summary>
    public interface IPoloniexRestClient : IRestClient<HMACCredential>
    {

        /// <summary>
        /// Exchange API endpoints
        /// </summary>
        public IPoloniexRestClientExchangeApi ExchangeApi { get; }
    }
}
