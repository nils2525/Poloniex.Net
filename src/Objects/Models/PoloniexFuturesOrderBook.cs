using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>
    /// Futures level 2 order book update.
    /// </summary>
    public class PoloniexFuturesOrderBook
    {
        /// <summary>
        /// Symbol.
        /// </summary>
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Previous version id.
        /// </summary>
        [JsonPropertyName("lid")]
        public long PreviousSequence { get; set; }

        /// <summary>
        /// Current version id.
        /// </summary>
        [JsonPropertyName("id")]
        public long Sequence { get; set; }

        /// <summary>
        /// Ask levels.
        /// </summary>
        [JsonPropertyName("asks")]
        public PoloniexOrderBookEntry[] Asks { get; set; } = [];

        /// <summary>
        /// Bid levels.
        /// </summary>
        [JsonPropertyName("bids")]
        public PoloniexOrderBookEntry[] Bids { get; set; } = [];

        /// <summary>
        /// Push time.
        /// </summary>
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Create time.
        /// </summary>
        [JsonPropertyName("cT")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
    }
}
