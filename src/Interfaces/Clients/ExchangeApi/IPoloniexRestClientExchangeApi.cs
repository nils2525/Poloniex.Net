using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Interfaces.Clients;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange API endpoints
    /// </summary>
    public interface IPoloniexRestClientExchangeApi : IRestApiClient, IDisposable
    {
        /// <summary>
        /// Endpoints related to account settings, info or actions
        /// </summary>
        public IPoloniexClientExchangeApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to retrieving market and system data
        /// </summary>
        public IPoloniexRestClientExchangeApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to orders and trades
        /// </summary>
        public IPoloniexRestClientExchangeApiTrading Trading { get; }
    }
}
