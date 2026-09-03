using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
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
            parameters.Add("side", side is PoloniexTradeSide.Buy ? "BUY" : "SELL");
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
            parameters.AddOptionalEnum("direct", direction);
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
            parameters.AddOptionalEnum("direct", direction);
            var request = _definitions.GetOrCreate(HttpMethod.Get, "v3/trade/order/trades",
                PoloniexExchange.RateLimiter.FuturesPrivate, 1, true);
            return _baseClient.SendFuturesAsync<PoloniexFuturesOrderTrade[]>(request, parameters, ct);
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
