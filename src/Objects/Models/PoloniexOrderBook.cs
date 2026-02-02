using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexOrderBook
    {
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = String.Empty;

        /// <summary>
        /// The id of the previous message
        /// </summary>
        [JsonPropertyName("lastId")]
        public long PreviousSequence { get; set; }

        /// <summary>
        /// The id of the record (SeqId)
        /// </summary>
        [JsonPropertyName("id")]
        public long Sequence { get; set; }

        [JsonPropertyName("bids")]
        public IEnumerable<PoloniexOrderBookEntry> Bids { get; set; } = Array.Empty<PoloniexOrderBookEntry>();

        [JsonPropertyName("asks")]
        public IEnumerable<PoloniexOrderBookEntry> Asks { get; set; } = Array.Empty<PoloniexOrderBookEntry>();
    }
}
