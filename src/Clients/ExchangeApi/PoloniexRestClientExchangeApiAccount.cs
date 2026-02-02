using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class PoloniexRestClientExchangeApiAccount : IPoloniexClientExchangeApiAccount
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly PoloniexRestClientExchangeApi _baseClient;

        internal PoloniexRestClientExchangeApiAccount(PoloniexRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
        }

        public Task<WebCallResult<PoloniexAccountBalance[]>> GetAccountBalancesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "accounts/balances", PoloniexExchange.RateLimiter.RestPrivate, 1, true);
            return _baseClient.SendAsync<PoloniexAccountBalance[]>(request, null, ct);
        }

        public Task<WebCallResult<PoloniexAccount[]>> GetAccountDetailsAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "accounts", PoloniexExchange.RateLimiter.RestPrivate, 1, true);
            return _baseClient.SendAsync<PoloniexAccount[]>(request, null, ct);
        }

        public Task<WebCallResult<PoloniexAccountFee>> GetFeeRatesAsync(CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, "feeinfo", PoloniexExchange.RateLimiter.RestPrivateSpecific, 1, true);
            return _baseClient.SendAsync<PoloniexAccountFee>(request, null, ct);
        }

        public Task<WebCallResult<PoloniexWalletActivity>> GetWalletActivityAsync(DateTime startDate, DateTime endDate, PoloniexWalletActivityType? activityType = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddSeconds("start", startDate);
            parameters.AddSeconds("end", endDate);
            parameters.AddOptionalEnum("activityType", activityType);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "wallets/activity", PoloniexExchange.RateLimiter.RestPrivateSpecific, 1, true);
            return _baseClient.SendAsync<PoloniexWalletActivity>(request, parameters, ct);
        }

        public Task<WebCallResult<PoloniexAccountActivity[]>> GetAccountActivityAsync(DateTime? startDate = null, DateTime? endDate = null, PoloniexAccountActivityType? activityType = null, int? limit = null, long? from = null, PoloniexAccountActivityDirection? direction = null, string? asset = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptionalMilliseconds("startTime", startDate);
            parameters.AddOptionalMilliseconds("endTime", endDate);
            parameters.AddOptionalEnum("activityType", activityType);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("from", from);
            parameters.AddOptionalEnum("direction", direction);
            parameters.AddOptional("currency", asset);

            var request = _definitions.GetOrCreate(HttpMethod.Get, "accounts/activity", PoloniexExchange.RateLimiter.RestPrivateSpecific, 1, true);
            return _baseClient.SendAsync<PoloniexAccountActivity[]>(request, parameters, ct);
        }
    }
}
