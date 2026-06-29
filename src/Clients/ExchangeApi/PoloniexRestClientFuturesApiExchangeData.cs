using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class PoloniexRestClientFuturesApiExchangeData : IPoloniexRestClientFuturesApiExchangeData
    {
        private readonly PoloniexRestClientFuturesApi _baseClient;
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();

        internal PoloniexRestClientFuturesApiExchangeData(ILogger logger, PoloniexRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public async Task<HttpResult<PoloniexFuturesInstrument[]>> GetInstrumentsAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/market/allInstruments", PoloniexExchange.RateLimiter.RestPublicSpecific, 1, false);
            var result = await _baseClient.SendAsync<PoloniexFuturesRestResult<PoloniexFuturesInstrument[]>>(request, parameters, ct).ConfigureAwait(false);
            return result.As<PoloniexFuturesInstrument[]>(result.Data?.Data);
        }
    }
}
