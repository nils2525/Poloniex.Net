using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
using Poloniex.Net.ExtensionMethods;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc />
    internal class PoloniexRestClientFuturesApiTrading : IPoloniexRestClientFuturesApiTrading
    {
        private static readonly RequestDefinitionCache _definitions = new();
        private readonly PoloniexRestClientFuturesApi _baseClient;

        internal PoloniexRestClientFuturesApiTrading(PoloniexRestClientFuturesApi baseClient)
        {
            _baseClient = baseClient;
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrderId>> PlaceOrderAsync(string symbol,
            PoloniexTradeSide side, PoloniexFuturesMarginMode marginMode,
            PoloniexFuturesPositionSide positionSide, PoloniexOrderType type, decimal quantity,
            decimal? price = null, string? clientOrderId = null, bool? reduceOnly = null,
            PoloniexOrderTimeInForce? timeInForce = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            // V3 futures requires upper-case BUY/SELL, while the shared spot enum
            // intentionally serializes lower-case values.
            parameters.Add("side", side.ToFuturesValue());
            parameters.AddEnum("mgnMode", marginMode);
            parameters.AddEnum("posSide", positionSide);
            parameters.AddEnum("type", type);
            parameters.AddOptional("clOrdId", clientOrderId);
            parameters.AddOptional("px", price);
            parameters.Add("sz", quantity);
            if (reduceOnly.HasValue)
                parameters.Add("reduceOnly", reduceOnly.Value);
            parameters.AddOptionalEnum("timeInForce", timeInForce);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v3/trade/order",
                PoloniexExchange.RateLimiter.FuturesPlaceOrder, 1, true,
                parameterPosition: HttpMethodParameterPosition.InBody);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrderId>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrderId>> CancelOrderAsync(string symbol,
            string? orderId = null, string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.AddOptional("ordId", orderId);
            parameters.AddOptional("clOrdId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Delete, "v3/trade/order",
                PoloniexExchange.RateLimiter.FuturesCancelOrder, 1, true,
                parameterPosition: HttpMethodParameterPosition.InBody);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrderId>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrder[]>> GetOpenOrdersAsync(string? symbol = null,
            string? orderId = null, string? clientOrderId = null, string? from = null,
            int? limit = null, PoloniexPageDirection? direction = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("ordId", orderId);
            parameters.AddOptional("clOrdId", clientOrderId);
            parameters.AddOptional("from", from);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("direct", direction?.ToFuturesValue());
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/order/opens",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrder[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrder>> GetOrderAsync(string? orderId = null,
            string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("ordId", orderId);
            parameters.AddOptional("clOrdId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/order/details",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrder>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrderTrade[]>> GetOrderTradesAsync(string? symbol = null,
            string? orderId = null, string? clientOrderId = null, string? from = null,
            int? limit = null, PoloniexPageDirection? direction = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("ordId", orderId);
            parameters.AddOptional("clOrdId", clientOrderId);
            parameters.AddOptional("from", from);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("direct", direction?.ToFuturesValue());
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/order/trades",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrderTrade[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrderTrade[]>> GetOrderTradeHistoryAsync(
            PoloniexTradeSide? side = null, string? symbol = null, string? orderId = null,
            string? clientOrderId = null, DateTime? startTime = null, DateTime? endTime = null,
            string? from = null, int? limit = null, PoloniexPageDirection? direction = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("side", side?.ToFuturesValue());
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("ordId", orderId);
            parameters.AddOptional("clOrdId", clientOrderId);
            parameters.AddOptionalMilliseconds("sTime", startTime);
            parameters.AddOptionalMilliseconds("eTime", endTime);
            parameters.AddOptional("from", from);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("direct", direction?.ToFuturesValue());
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/order/trades",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrderTrade[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrder[]>> GetOrderHistoryAsync(string? symbol = null,
            PoloniexTradeSide? side = null, string? orderId = null, string? clientOrderId = null,
            PoloniexOrderState? state = null, PoloniexOrderType? type = null,
            DateTime? startTime = null, DateTime? endTime = null, string? from = null,
            int? limit = null, PoloniexPageDirection? direction = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptional("side", side?.ToFuturesValue());
            parameters.AddOptional("ordId", orderId);
            parameters.AddOptional("clOrdId", clientOrderId);
            parameters.AddOptionalEnum("state", state);
            parameters.AddOptionalEnum("type", type);
            parameters.AddOptionalMilliseconds("sTime", startTime);
            parameters.AddOptionalMilliseconds("eTime", endTime);
            parameters.AddOptional("from", from);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("direct", direction?.ToFuturesValue());
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/order/history",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrder[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesPosition[]>> GetOpenPositionsAsync(string? symbol = null,
            CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("symbol", symbol);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/position/opens",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesPosition[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesPositionHistory[]>> GetPositionHistoryAsync(
            string? symbol = null, PoloniexFuturesMarginMode? marginMode = null,
            PoloniexFuturesPositionSide? positionSide = null, DateTime? startTime = null,
            DateTime? endTime = null, string? from = null, int? limit = null,
            PoloniexPageDirection? direction = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.AddOptional("symbol", symbol);
            parameters.AddOptionalEnum("mgnMode", marginMode);
            parameters.AddOptionalEnum("posSide", positionSide);
            parameters.AddOptionalMilliseconds("sTime", startTime);
            parameters.AddOptionalMilliseconds("eTime", endTime);
            parameters.AddOptional("from", from);
            parameters.AddOptional("limit", limit);
            parameters.AddOptional("direct", direction?.ToFuturesValue());
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/position/history",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesPositionHistory[]>(request, parameters, ct);
        }

        /// <inheritdoc />
        public Task<HttpResult<PoloniexFuturesOrderId>> ClosePositionAsync(string symbol,
            PoloniexFuturesMarginMode marginMode, PoloniexFuturesPositionSide? positionSide = null,
            string? clientOrderId = null, CancellationToken ct = default)
        {
            var parameters = new Parameters(PoloniexExchange._parameterSerializationSettings);
            parameters.Add("symbol", symbol);
            parameters.AddEnum("mgnMode", marginMode);
            parameters.AddOptionalEnum("posSide", positionSide);
            parameters.AddOptional("clOrdId", clientOrderId);
            var request = _definitions.GetOrCreate(HttpMethod.Post, "v3/trade/position",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true,
                parameterPosition: HttpMethodParameterPosition.InBody);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrderId>(request, parameters, ct);
        }
    }
}
