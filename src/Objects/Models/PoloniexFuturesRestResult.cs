using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    internal class PoloniexFuturesRestResult<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("msg")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("data")]
        public T Data { get; set; } = default!;
    }
}
