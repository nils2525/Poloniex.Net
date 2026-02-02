using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexOrderUpdate
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public PoloniexOrderType Type { get; set; }

        [JsonPropertyName("quantity")]
        public decimal OrderAmount { get; set; }

        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;

        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; } = string.Empty;

        [JsonPropertyName("feeCurrency")]
        public string FeeCurrency { get; set; } = string.Empty;

        [JsonPropertyName("eventType")]
        public PoloniexOrderUpdateEventType EventType { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;

        [JsonPropertyName("side")]
        public PoloniexTradeSide Side { get; set; }

        [JsonPropertyName("filledAmount")]
        public decimal FilledQuoteAmount { get; set; }

        [JsonPropertyName("filledQuantity")]
        public decimal FilledAmount { get; set; }

        [JsonPropertyName("matchRole")]
        public PoloniexTradeMatchRole? Role { get; set; }

        [JsonPropertyName("state")]
        public PoloniexOrderState State { get; set; }

        [JsonPropertyName("tradeFee")]
        public decimal? LastTradeFee { get; set; }

        [JsonPropertyName("tradeTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? LastTradeTime { get; set; }

        [JsonPropertyName("tradeAmount")]
        public decimal? LastTradeQuoteAmount { get; set; }

        [JsonPropertyName("tradeQty")]
        public decimal? LastTradeAmount { get; set; }

        [JsonPropertyName("tradePrice")]
        public decimal? LastTradePrice { get; set; }

        [JsonPropertyName("tradeId")]
        public string? LastTrdeId { get; set; }

        [JsonPropertyName("orderAmount")]
        public decimal QuoteAmount { get; set; }

        [JsonPropertyName("createTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// The time the record was pushed
        /// </summary>
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Timestamp { get; set; }
    }
}
