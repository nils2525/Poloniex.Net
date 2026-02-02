using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Internal
{
    internal class PoloniexSocketResponse<T> : PoloniexSocketResponseBase
    {
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }

    internal class PoloniexSocketSubscriptionResponse : PoloniexSocketResponseBase
    {

        [JsonPropertyName("symbols")]
        public string[] Symbols { get; set; } = [];

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }

    internal abstract class PoloniexSocketResponseBase
    {
        [JsonPropertyName("event")]
        public string Method { get; set; } = string.Empty;

        [JsonPropertyName("channel")]
        public string Channel { get; set; } = string.Empty;
    }
}
