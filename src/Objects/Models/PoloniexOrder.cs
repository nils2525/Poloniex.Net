using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexOrder : PoloniexOrderId
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public PoloniexOrderState State { get; set; }

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; } = string.Empty;

        [JsonPropertyName("side")]
        public PoloniexTradeSide Side { get; set; }

        [JsonPropertyName("type")]
        public PoloniexOrderType Type { get; set; }

        [JsonPropertyName("timeInForce")]
        public string TimeInForce { get; set; } = string.Empty;

        [JsonPropertyName("quantity")]
        public decimal Amount { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("avgPrice")]
        public decimal? AveragePrice { get; set; }

        [JsonPropertyName("amount")]
        public decimal QuoteAmount { get; set; }

        [JsonPropertyName("filledQuantity")]
        public decimal FilledAmount { get; set; }

        [JsonPropertyName("filledAmount")]
        public decimal FilledQuoteAmount { get; set; }

        [JsonPropertyName("createTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }

        [JsonPropertyName("updateTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }

        [JsonPropertyName("orderSource")]
        public string OrderSource { get; set; } = string.Empty;

        [JsonPropertyName("loan")]
        public bool Loan { get; set; }

        [JsonPropertyName("cancelReason")]
        public int? CancelReason { get; set; }
    }
}
