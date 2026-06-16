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
    }
}
