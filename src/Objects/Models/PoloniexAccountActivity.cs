using System.Text.Json.Serialization;
using Poloniex.Net.Enums;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexAccountActivity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("state")]
        public PoloniexAccountActivityStatus Status { get; set; }

        [JsonPropertyName("createTime")]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("activityType")]
        public PoloniexAccountActivityType ActivityType { get; set; }
    }
}
