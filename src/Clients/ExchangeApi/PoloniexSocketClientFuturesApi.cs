using System.Net.WebSockets;
using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Sockets;
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
    /// <inheritdoc cref="IPoloniexSocketClientFuturesApi" />
    internal class PoloniexSocketClientFuturesApi : SocketApiClient<PoloniexEnvironment, PoloniexAuthenticationProvider, HMACCredential>, IPoloniexSocketClientFuturesApi
    {
        internal PoloniexSocketClientFuturesApi(ILoggerFactory? loggerFactory, PoloniexSocketOptions options)
            : base(loggerFactory, PoloniexExchange.ExchangeName, options.Environment.SocketClientAddress!, options, options.ExchangeOptions)
        {
            RateLimiter = PoloniexExchange.RateLimiter.Socket;
            RegisterPeriodicQuery("pong", TimeSpan.FromSeconds(10), (c) => new PoloniexPingQuery(false), (connection, result) =>
            {
                if (result.Error?.Message?.Equals("Query timeout") == true)
                {
                    _logger.LogWarning("[Sckt {SocketId}] Ping response timeout, reconnecting", connection.SocketId);
                    _ = connection.TriggerReconnectAsync();
                }
            });
        }

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(PoloniexExchange.SerializerContext));

        /// <inheritdoc />
        protected override PoloniexAuthenticationProvider CreateAuthenticationProvider(HMACCredential credentials)
            => new PoloniexAuthenticationProvider(credentials);

        /// <inheritdoc />
        public override ISocketMessageHandler CreateMessageConverter(WebSocketMessageType messageType)
            => new PoloniexSocketMessageHandler();

        /// <inheritdoc />
        public Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(string symbol, Action<DataEvent<PoloniexFuturesTrade[]>> onMessage, CancellationToken ct = default)
            => SubscribeToTradeUpdatesAsync([symbol], onMessage, ct);

        /// <inheritdoc />
        public async Task<WebSocketResult<UpdateSubscription>> SubscribeToTradeUpdatesAsync(IEnumerable<string> symbols, Action<DataEvent<PoloniexFuturesTrade[]>> onMessage, CancellationToken ct = default)
        {
            var symbolArray = symbols.ToArray();
            var internalHandler = new Action<DateTime, string?, PoloniexSubscriptionEvent<PoloniexFuturesTrade>>((receiveTime, originalData, data) =>
            {
                DateTime? timestamp = data.Data.Any() ? data.Data.Max(c => c.CreateTime) : null;
                if (timestamp.HasValue)
                    UpdateTimeOffset(timestamp.Value);

                onMessage(
                    new DataEvent<PoloniexFuturesTrade[]>(PoloniexExchange.ExchangeName, data.Data, receiveTime, originalData)
                        .WithUpdateType(data.Action.ToCEN())
                        .WithSymbol(symbolArray.Length == 1 ? symbolArray[0] : null)
                        .WithStreamId(data.Channel)
                        .WithDataTimestamp(timestamp, GetTimeOffset())
                    );
            });
            var subscription = new PoloniexSubscription<PoloniexFuturesTrade>(_logger, "trades", symbolArray, internalHandler, false)
            {
                IndividualSubscriptionCount = symbolArray.Length
            };
            return await SubscribeAsync(BaseAddress.AppendPath("v3/public"), subscription, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override Task<Query?> GetAuthenticationRequestAsync(SocketConnection connection)
            => Task.FromResult<Query?>(null);

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, CryptoExchange.Net.SharedApis.TradingMode tradingMode, DateTime? deliverTime = null)
            => PoloniexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
