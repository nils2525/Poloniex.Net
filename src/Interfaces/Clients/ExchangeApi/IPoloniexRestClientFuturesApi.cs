namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Poloniex futures REST API endpoints.
    /// </summary>
    public interface IPoloniexRestClientFuturesApi
    {
        /// <summary>
        /// Futures exchange data endpoints.
        /// </summary>
        public IPoloniexRestClientFuturesApiExchangeData ExchangeData { get; }

        /// <summary>Futures account endpoints.</summary>
        public IPoloniexRestClientFuturesApiAccount Account { get; }

        /// <summary>Futures trading and position endpoints.</summary>
        public IPoloniexRestClientFuturesApiTrading Trading { get; }
    }
}
