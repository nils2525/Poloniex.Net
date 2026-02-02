using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexBalanceUpdate
    {
        /// <summary>
        /// Time the change was executed
        /// </summary>
        [JsonPropertyName("changeTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ChangeTime { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; } = string.Empty;

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; } = string.Empty;

        /// <summary>
        /// There are 7 different types of events: "place_order", "canceled_order","match_order", "transfer_in", "transfer_out", "deposit","withdraw"
        /// </summary>
        [JsonPropertyName("event_type")]
        public string EventType { get; set; } = string.Empty;

        [JsonPropertyName("available")]
        public decimal Available { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// Id of the asset update
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("hold")]
        public decimal Hold { get; set; }

        /// <summary>
        /// Time the record was pushed
        /// </summary>
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
