using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexOrderTrade
    {
        [JsonPropertyName("orderId")]
        public string OrderId { get; set; } = string.Empty;

        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }

        [JsonPropertyName("id")]
        public string TradeId { get; set; } = string.Empty;

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; } = string.Empty;

        [JsonPropertyName("side")]
        public PoloniexTradeSide Side { get; set; }

        [JsonPropertyName("type")]
        public PoloniexOrderType Type { get; set; }

        [JsonPropertyName("matchRole")]
        public PoloniexTradeMatchRole Role { get; set; }

        [JsonPropertyName("createTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("quantity")]
        public decimal Amount { get; set; }

        [JsonPropertyName("amount")]
        public decimal QuoteAmount { get; set; }

        [JsonPropertyName("feeCurrency")]
        public string FeeCurrency { get; set; } = string.Empty;

        [JsonPropertyName("feeAmount")]
        public decimal FeeAmount { get; set; }

        [JsonPropertyName("pageId")]
        public long PageId { get; set; }
    }
}
