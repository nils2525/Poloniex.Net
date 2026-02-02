using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Enums;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class PoloniexRestClientExchangeApiTrading : IPoloniexRestClientExchangeApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new RequestDefinitionCache();
        private readonly PoloniexRestClientExchangeApi _baseClient;
        private readonly ILogger _logger;

        internal PoloniexRestClientExchangeApiTrading(ILogger logger, PoloniexRestClientExchangeApi baseClient)
        {
            _baseClient = baseClient;
            _logger = logger;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PoloniexOrderId>> PlaceOrderAsync(string symbol, PoloniexTradeSide side, PoloniexOrderType type, decimal price, decimal quantity, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.Add("symbol", symbol);
            parameters.AddEnum("side", side);
            parameters.AddEnum("type", type);
            parameters.Add("price", price);
            parameters.Add("quantity", quantity);
            parameters.AddOptional("clientOrderId", clientOrderId);

            var request = _definitions.GetOrCreate(HttpMethod.Post, "orders", PoloniexExchange.RateLimiter.RestPrivate, 1, true, parameterPosition: HttpMethodParameterPosition.InBody);
            var result = await _baseClient.SendAsync<PoloniexOrderId>(request, parameters, ct).ConfigureAwait(false);
            return result;
        }

        /// <inheritdoc />
        public async Task<WebCallResult<PoloniexCancelOrderResult>> CancelOrderAsync(string orderId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Delete, $"orders/{orderId}", PoloniexExchange.RateLimiter.RestPrivate, 1, true);
            var result = await _baseClient.SendAsync<PoloniexCancelOrderResult>(request, null, ct);
            if (result.Error == null && result.Data?.Code != 200)
                return result.AsError<PoloniexCancelOrderResult>(new ServerError(result.Data?.Code ?? -1, new(ErrorType.Unknown, result.Data?.Message ?? "Data is null")));

            return result;
        }

        public Task<WebCallResult<PoloniexOrder[]>> GetOpenOrdersAsync(string? symbol = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"orders", PoloniexExchange.RateLimiter.RestPrivateSpecific, 1, true);
            return _baseClient.SendAsync<PoloniexOrder[]>(request, parameters, ct);
        }

        public Task<WebCallResult<PoloniexOrder>> GetOrderByIdAsync(string orderId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"orders/{orderId}", PoloniexExchange.RateLimiter.RestPrivate, 1, true);
            return _baseClient.SendAsync<PoloniexOrder>(request, null, ct);
        }

        public Task<WebCallResult<PoloniexOrderTrade[]>> GetOrderTradesAsync(string orderId, CancellationToken ct = default)
        {
            var request = _definitions.GetOrCreate(HttpMethod.Get, $"orders/{orderId}/trades", PoloniexExchange.RateLimiter.RestPrivate, 1, true);
            return _baseClient.SendAsync<PoloniexOrderTrade[]>(request, null, ct);
        }

        public Task<WebCallResult<PoloniexOrderTrade[]>> GetOrderTradeHistoryAsync(int? limit = null, DateTime? startTime = null, DateTime? endTime = null, long? from = null, PoloniexPageDirection? pageDirection = null, string[]? symbols = null, CancellationToken ct = default)
        {
            var parameters = new ParameterCollection();
            parameters.AddOptional("limit", limit);
            parameters.AddOptionalMilliseconds("startTime", startTime);
            parameters.AddOptionalMilliseconds("endTime", endTime);
            parameters.AddOptional("from", from);
            parameters.AddOptional("symbols", symbols != null ? String.Join(",", symbols) : null);
            parameters.AddOptionalEnum("pageDirection", pageDirection);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "trades", PoloniexExchange.RateLimiter.RestPrivate, 1, true);
            return _baseClient.SendAsync<PoloniexOrderTrade[]>(request, parameters, ct);
        }
    }
}
