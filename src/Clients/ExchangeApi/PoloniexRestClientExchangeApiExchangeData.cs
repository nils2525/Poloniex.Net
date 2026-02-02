using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class PoloniexRestClientExchangeApiExchangeData : IPoloniexRestClientExchangeApiExchangeData
    {
        private readonly PoloniexRestClientExchangeApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal PoloniexRestClientExchangeApiExchangeData(ILogger logger, PoloniexRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
        }

        #region Get Server Time

        /// <inheritdoc />
        public async Task<WebCallResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default)
        {
            // No dedicated endpoint, use ticker endpoint which returns a timestamp
            var request = _definitions.GetOrCreate(HttpMethod.Get, "timestamp", PoloniexExchange.RateLimiter.RestPublic, 1, false);
            var result = await _baseClient.SendAsync<PoloniexTimestamp>(request, null, ct).ConfigureAwait(false);
            return result.As(result.Data.Timestamp);
        }

        #endregion

        #region Get Symbols

        /// <inheritdoc />
        public async Task<WebCallResult<PoloniexSymbol[]>> GetSymbolsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "markets", PoloniexExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<PoloniexSymbol[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PoloniexCurrency[]>> GetCurrencyInformationAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v2/currencies", PoloniexExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<PoloniexCurrency[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        public async Task<WebCallResult<PoloniexTicker[]>> GetTickersAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "markets/ticker24h", PoloniexExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<PoloniexTicker[]>(request, null, ct).ConfigureAwait(false);
            return result;
        }

        public async Task<WebCallResult<PoloniexTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"markets/{symbol}/ticker24h", PoloniexExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<PoloniexTicker>(request, null, ct).ConfigureAwait(false);
            return result;
        }
        #endregion

    }
}
