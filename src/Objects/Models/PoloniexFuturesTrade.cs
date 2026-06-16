using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>
    /// Futures trade update.
    /// </summary>
    public class PoloniexFuturesTrade
    {
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("side")]
        public PoloniexTradeSide Side { get; set; }

        [JsonPropertyName("px")]
        public decimal Price { get; set; }

        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }

        [JsonPropertyName("amt")]
        public decimal QuoteQuantity { get; set; }

        [JsonPropertyName("id")]
        public long TradeId { get; set; }

        [JsonPropertyName("cT")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
