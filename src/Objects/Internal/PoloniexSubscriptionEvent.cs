using System.Text.Json.Serialization;
using Poloniex.Net.Enums;

namespace Poloniex.Net.Objects.Internal
{
    internal class PoloniexSubscriptionEvent<T>
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;

        [JsonPropertyName("action")]
        public PoloniexSocketAction Action { get; set; } = PoloniexSocketAction.Update;

        [JsonPropertyName("data")]
        public T[] Data { get; set; } = [];
    }
}
