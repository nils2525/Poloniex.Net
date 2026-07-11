using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using CryptoExchange.Net.Sockets.Default.Routing;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Objects.Internal;

namespace Poloniex.Net.Objects.Sockets.Subscriptions
{
    /// <inheritdoc />
    internal class PoloniexSubscription<T> : Subscription
    {
        public const string AllSymbols = "ALL";

        private readonly string _channel;
        private readonly string[] _symbols;
        private readonly Action<DateTime, string?, PoloniexSubscriptionEvent<T>> _handler;

        /// <summary>
        /// ctor
        /// </summary>
        public PoloniexSubscription(ILogger logger, string channel, string[] symbols, Action<DateTime, string?, PoloniexSubscriptionEvent<T>> handler, bool auth, Dictionary<string, object>? parameters = null, bool firstUpdateSnapshot = false) : base(logger, auth)
        {
            _handler = handler;
            _channel = channel;
            _symbols = symbols;

            var isAllSymbols = symbols.Length == 1 && string.Equals(symbols[0], AllSymbols, StringComparison.OrdinalIgnoreCase);
            IndividualSubscriptionCount = symbols.Length;

            if (isAllSymbols)
                MessageRouter = MessageRouter.CreateForEvent<PoloniexSubscriptionEvent<T>>(channel, DoHandleMessage);
            else
                MessageRouter = MessageRouter.Create(symbols.Select(symbol => MessageRoute.CreateForEvent<PoloniexSubscriptionEvent<T>>(channel, symbol, DoHandleMessage)).ToArray());
        }

        /// <inheritdoc />
        protected override Query? GetSubQuery(SocketConnection connection)
        {
            var request = new PoloniexSocketRequest
            {
                Method = "subscribe",
                Channels = [_channel],
                Symbols = _symbols
            };

            return new PoloniexQuerySubscription(request, Authenticated)
            {
                RequiredResponses = request.Channels.Length
            };
        }

        /// <inheritdoc />
        protected override Query? GetUnsubQuery(SocketConnection connection)
        {
            return new PoloniexQuerySubscription(new PoloniexSocketRequest
            {
                Method = "unsubscribe",
                Channels = [_channel],
                Symbols = _symbols
            }, Authenticated);
        }

        /// <inheritdoc />
        public CallResult DoHandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, PoloniexSubscriptionEvent<T> message)
        {
            _handler.Invoke(receiveTime, originalData, message);
            return CallResult.Ok();
        }
    }
}
