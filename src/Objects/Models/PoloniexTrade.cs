using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexTrade
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal QuoteAmount { get; set; }

        [JsonPropertyName("takerSide")]
        public PoloniexTradeSide TakerSide { get; set; }

        [JsonPropertyName("quantity")]
        public decimal BaseAmount { get; set; }

        [JsonPropertyName("createTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("id")]
        public long TradeId { get; set; }

        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
