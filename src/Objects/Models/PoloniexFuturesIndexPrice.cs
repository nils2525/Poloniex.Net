using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>
    /// Futures index-price update.
    /// </summary>
    public class PoloniexFuturesIndexPrice
    {
        /// <summary>[<c>s</c>] Trading pair.</summary>
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>[<c>iPx</c>] Index price.</summary>
        [JsonPropertyName("iPx")]
        public decimal IndexPrice { get; set; }

        /// <summary>[<c>ts</c>] Push timestamp.</summary>
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
