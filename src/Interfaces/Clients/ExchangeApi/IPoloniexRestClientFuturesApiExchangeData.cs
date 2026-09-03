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

        /// <summary>
        /// Get 24-hour futures ticker information.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/market/get-market-info" /></para>
        /// </summary>
        /// <param name="symbol">Optional symbol filter.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<HttpResult<PoloniexFuturesTicker[]>> GetTickersAsync(string? symbol = null, CancellationToken ct = default);

        /// <summary>
        /// Get the current and predicted funding rate.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/market/get-current-funding-rate" /></para>
        /// </summary>
        /// <param name="symbol">Symbol.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<HttpResult<PoloniexFuturesFundingRate>> GetFundingRateAsync(string symbol, CancellationToken ct = default);
    }
}
