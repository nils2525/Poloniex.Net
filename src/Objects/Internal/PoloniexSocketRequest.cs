using System.Text.Json.Serialization;
using CryptoExchange.Net.Objects;
using Poloniex.Net.Objects.Sockets.Subscriptions;

namespace Poloniex.Net.Objects.Internal
{
    internal class PoloniexSocketRequest
    {
        internal static string ParseSubscriptionLisetenerIdentifier(string channel, string symbol)
            => $"{channel}#{symbol}";

        internal static string ParseQueryLisetenerIdentifier(string method, string channel, string symbol)
            => $"{method}#{channel}#{symbol}";

        [JsonPropertyName("event")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("channel")]
        public string[] Channels { get; set; } = [];

        [JsonPropertyName("symbols"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[] Symbols { get; set; } = [];

        [JsonPropertyName("params"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ParameterCollection? Parameters { get; set; }

        public PoloniexSocketRequest()
        { }

        public PoloniexSocketRequest(string method)
        {
            Method = method;
        }

        public IEnumerable<string> GetQueryLisetenerIdentifiers()
        {
            foreach (var channel in Channels)
            {
                if (Symbols.Length == 0 || Symbols.Length > 1 || (Symbols.Length == 1 && Symbols[0] == PoloniexSubscription<object>.AllSymbols))
                    yield return $"{Method}#{channel}";

                if (Symbols.Length > 0)
                    yield return $"{Method}#{channel}#{Symbols[0]}";
            }
        }

        public IEnumerable<string> GetSubscriptionLisetenerIdentifiers()
            => Channels.SelectMany(channel => Symbols.Select(symbol => ParseSubscriptionLisetenerIdentifier(channel, symbol)));
    }
}
