using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Current and predicted futures funding rate.</summary>
    public class PoloniexFuturesFundingRate
    {
        /// <summary>[<c>s</c>] Trading pair.</summary>
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>[<c>fR</c>] Current funding rate.</summary>
        [JsonPropertyName("fR")]
        public decimal FundingRate { get; set; }
        /// <summary>[<c>fT</c>] Most recent funding settlement time.</summary>
        [JsonPropertyName("fT"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime FundingTime { get; set; }
        /// <summary>[<c>nFR</c>] Predicted next funding rate.</summary>
        [JsonPropertyName("nFR")]
        public decimal PredictedFundingRate { get; set; }
        /// <summary>[<c>nFT</c>] Next funding settlement time.</summary>
        [JsonPropertyName("nFT"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime NextFundingTime { get; set; }
        /// <summary>[<c>ts</c>] Push time.</summary>
        [JsonPropertyName("ts"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Timestamp { get; set; }
    }
}
