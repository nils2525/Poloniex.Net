using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
using Poloniex.Net.ExtensionMethods;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class PoloniexRestClientFuturesApiAccount : IPoloniexRestClientFuturesApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new();
        private readonly PoloniexRestClientFuturesApi _baseClient;

        internal PoloniexRestClientFuturesApiAccount(PoloniexRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesAccountBalance>> GetBalancesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/account/balance",
                PoloniexExchange.RateLimiter.FuturesBalance, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesAccountBalance>(request, null, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesBill[]>> GetBillsAsync(DateTime? startTime = null,
            DateTime? endTime = null, string? from = null, int? limit = null,
            PoloniexPageDirection? direction = null, PoloniexFuturesBillType? type = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptionalMilliseconds("sTime", startTime);
            parameters.AddOptionalMilliseconds("eTime", endTime);
            parameters.AddOptional("from", from);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("direct", direction?.ToFuturesValue());
            parameters.AddOptionalEnum("type", type);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/account/bills",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesBill[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesPositionModeInfo>> GetPositionModeAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/position/mode",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesPositionModeInfo>(request, null, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<object>> SetPositionModeAsync(PoloniexFuturesPositionMode positionMode,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddEnum("posMode", positionMode);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v3/position/mode",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true,
                parameterPosition: HttpMethodParameterPosition.InBody);
            return _baseClient.SendFuturesAsync<object>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesLeverage[]>> GetLeveragesAsync(string symbol,
            PoloniexFuturesMarginMode? marginMode = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.AddOptionalEnum("mgnMode", marginMode);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/position/leverages",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesLeverage[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesLeverage>> SetLeverageAsync(string symbol,
            PoloniexFuturesMarginMode marginMode, PoloniexFuturesPositionSide positionSide,
            decimal leverage, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.AddEnum("mgnMode", marginMode);
            parameters.AddEnum("posSide", positionSide);
            parameters.Add("lever", leverage);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v3/position/leverage",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true,
                parameterPosition: HttpMethodParameterPosition.InBody);
            return _baseClient.SendFuturesAsync<PoloniexFuturesLeverage>(request, parameters, ct);
        }
    }
}
