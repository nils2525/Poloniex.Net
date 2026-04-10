using CryptoExchange.Net.Sockets;
using CryptoExchange.Net.Sockets.Default.Routing;
using Poloniex.Net.Objects.Internal;

namespace Poloniex.Net.Objects.Sockets
{
    internal class PoloniexPingQuery : Query<PoloniexSocketSubscriptionResponse>
    {
        public PoloniexPingQuery(bool authenticated, int weight = 1) : base(new PoloniexSocketRequest("ping"), authenticated, weight)
        {
            MessageRouter = MessageRouter.CreateWithoutTopicFilter<PoloniexSocketSubscriptionResponse>("pong",
                (_, _, _, message) => new CryptoExchange.Net.Objects.CallResult<PoloniexSocketSubscriptionResponse>(message));
        }
    }
}
