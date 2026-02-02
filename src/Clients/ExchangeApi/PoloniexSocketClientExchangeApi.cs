using System.Net.WebSockets;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
using CryptoExchange.Net.SharedApis;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Clients.MessageHandlers;
using Poloniex.Net.ExtensionMethods;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Internal;
using Poloniex.Net.Objects.Models;
using Poloniex.Net.Objects.Options;
using Poloniex.Net.Objects.Sockets;
using Poloniex.Net.Objects.Sockets.Subscriptions;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <summary>
    /// Client providing access to the CryptoCom Exchange websocket Api
    /// </summary>
    internal partial class PoloniexSocketClientExchangeApi : SocketApiClient, IPoloniexSocketClientExchangeApi
    {
        #region constructor/destructor

        /// <summary>
        /// ctor
        /// </summary>
        internal PoloniexSocketClientExchangeApi(ILogger logger, PoloniexSocketOptions options) :
            base(logger, options.Environment.SocketClientAddress!, options, options.ExchangeOptions)
        {
            RateLimiter = PoloniexExchange.RateLimiter.Socket;
            RegisterPeriodicQuery("pong", TimeSpan.FromSeconds(10), (c) => new PoloniexPingQuery(false), (connection, result) =>
            {
                if (result.Error?.Message?.Equals("Query timeout") == true)
                {
                    // Ping timeout, reconnect
                    _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                    _ = connection.TriggerReconnectAsync();
                }
            });
        }
        #endregion

        #region Subscriptions

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(PoloniexExchange.SerializerContext));

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new PoloniexAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType)
            => new PoloniexSocketMessageHandler();

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PoloniexTrade[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PoloniexSubscriptionEvent<PoloniexTrade>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.Timestamp) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<PoloniexTrade[]>(PoloniexExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new PoloniexSubscription<PoloniexTrade>(_logger, "trades", [symbol], internalHandler, false);
            return await SubscribeAsync(BaseAddress.AppendPath("public"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToCandleUpdatesAsync(string symbol, Action<DataEvent<PoloniexCandle[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PoloniexSubscriptionEvent<PoloniexCandle>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.Timestamp) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<PoloniexCandle[]>(PoloniexExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new PoloniexSubscription<PoloniexCandle>(_logger, "candles_minute_1", [symbol], internalHandler, false);
            return SubscribeAsync(BaseAddress.AppendPath("public"), subscription, ct);
        }

        /// <inheritdoc />
        public Task<CallResult<UpdateSubscription>> SubscribeToOrderBookUpdatesAsync(string symbol, Action<DataEvent<PoloniexOrderBook[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PoloniexSubscriptionEvent<PoloniexOrderBook>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.Timestamp) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<PoloniexOrderBook[]>(PoloniexExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(symbol)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new PoloniexSubscription<PoloniexOrderBook>(_logger, "book_lv2", [symbol], internalHandler, false);
            return SubscribeAsync(BaseAddress.AppendPath("public"), subscription, ct);
        }

        public Task<CallResult<UpdateSubscription>> SubscribeToOrderUpdatesAsync(Action<DataEvent<PoloniexOrderUpdate[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PoloniexSubscriptionEvent<PoloniexOrderUpdate>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.Timestamp) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<PoloniexOrderUpdate[]>(PoloniexExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new PoloniexSubscription<PoloniexOrderUpdate>(_logger, "orders", [PoloniexSubscription<object>.AllSymbols], internalHandler, true);
            return SubscribeAsync(BaseAddress.AppendPath("private"), subscription, ct);
        }

        public Task<CallResult<UpdateSubscription>> SubscribeToBalanceUpdatesAsync(Action<DataEvent<PoloniexBalanceUpdate[]>> onMessage, CancellationToken ct = default)
        {
            var internalHandler = new Action<DateTime, string?, PoloniexSubscriptionEvent<PoloniexBalanceUpdate>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.Timestamp) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<PoloniexBalanceUpdate[]>(PoloniexExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new PoloniexSubscription<PoloniexBalanceUpdate>(_logger, "balances", [PoloniexSubscription<object>.AllSymbols], internalHandler, true);
            return SubscribeAsync(BaseAddress.AppendPath("private"), subscription, ct);
        }
        #endregion

        #region Queries
        #endregion

        /// <inheritdoc />
        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
        {
            var authProvider = (PoloniexAuthenticationProvider)AuthenticationProvider!;
            var authParams = authProvider.AuthenticateSocket();
            return Task.FromResult<Query?>(new PoloniexQuery<PoloniexSocketAuthResponse>(new("subscribe")
            {
                Channels = ["auth"],
                Parameters = authParams
            }, "auth", false, 1));
        }

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => PoloniexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
