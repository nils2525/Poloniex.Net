using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default;
using Poloniex.Net.Objects.Internal;
using Poloniex.Net.Objects.Sockets.Subscriptions;

namespace Poloniex.Net.Objects.Sockets
{
    internal class PoloniexQuerySubscription : PoloniexQueryBase<PoloniexSocketSubscriptionResponse>
    {
        public PoloniexQuerySubscription(PoloniexSocketRequest request, bool authenticated, int weight = 1)
            : base(request, authenticated, weight)
        { }
    }

    internal class PoloniexQuery<T> : PoloniexQueryBase<PoloniexSocketResponse<T>>
    {
        public PoloniexQuery(PoloniexSocketRequest request, bool authenticated, int weight = 1) : base(request, authenticated, weight)
        { }

        public PoloniexQuery(PoloniexSocketRequest request, string listenerIdentifier, bool authenticated, int weight = 1)
            : base(request, listenerIdentifier, authenticated, weight)
        { }
    }

    internal abstract class PoloniexQueryBase<T> : Query<T>
        where T : PoloniexSocketResponseBase
    {
        public PoloniexQueryBase(PoloniexSocketRequest request, bool authenticated, int weight = 1)
            : base(request, authenticated, weight)
        {
            var routers = request.Channels.Select(channel => MessageRoute<T>.CreateWithTopicFilter($"{request.Method}#{channel}", String.Join(",", request.Symbols.Order()), HandleMessage));

            if (request.Symbols.Length == 1 && request.Symbols[0] == PoloniexSubscription<T>.AllSymbols)
                // Some channels response do not include the "ALL" symbol
                routers = request.Channels.Select(channel => MessageRoute<T>.CreateWithoutTopicFilter($"{request.Method}#{channel}", HandleMessage));

            // Include error responses
            routers = routers.Append(MessageRoute<T>.CreateWithoutTopicFilter("error", HandleMessage));

            MessageRouter = MessageRouter.Create(routers.ToArray());
        }

        public PoloniexQueryBase(PoloniexSocketRequest request, string listenerIdentifier, bool authenticated, int weight = 1)
            : base(request, authenticated, weight)
        {
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<T>([listenerIdentifier, "error"], HandleMessage);
        }

        public CallResult<T> HandleMessage(SocketConnection connection, DateTime receiveTime, string? originalData, T message)
        {
            if (message is PoloniexSocketSubscriptionResponse subResponse && message.Method == "error")
                return new CallResult<T>(new ServerError(new(CryptoExchange.Net.Objects.Errors.ErrorType.Unknown, subResponse.Message ?? "Unknown error while subscribing")));

            return new CallResult<T>(message, originalData, null);
        }
    }
}
