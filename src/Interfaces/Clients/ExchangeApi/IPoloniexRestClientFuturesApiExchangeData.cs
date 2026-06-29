using CryptoExchange.Net.Objects;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// Poloniex futures exchange data endpoints.
    /// </summary>
    public interface IPoloniexRestClientFuturesApiExchangeData
    {
        /// <summary>
        /// Get futures product information.
        /// </summary>
        /// <param name="symbol">Filter by symbol</param>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<PoloniexFuturesInstrument[]>> GetInstrumentsAsync(string? symbol = null, CancellationToken ct = default);
    }
}
