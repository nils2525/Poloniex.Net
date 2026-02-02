using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexTimestamp
    {
        [JsonPropertyName("serverTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
