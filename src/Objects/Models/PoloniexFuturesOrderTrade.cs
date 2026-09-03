using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures order execution information.</summary>
    public class PoloniexFuturesOrderTrade
    {
        /// <summary>[<c>id</c>] Pagination identifier.</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>[<c>symbol</c>] Trading pair.</summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>[<c>clOrdId</c>] Client order identifier.</summary>
        [JsonPropertyName("clOrdId")]
        public string? ClientOrderId { get; set; }
        /// <summary>[<c>ordId</c>] Exchange order identifier.</summary>
        [JsonPropertyName("ordId")]
        public string OrderId { get; set; } = string.Empty;
        /// <summary>[<c>trdId</c>] Trade identifier.</summary>
        [JsonPropertyName("trdId")]
        public string TradeId { get; set; } = string.Empty;
        /// <summary>[<c>side</c>] Trade side.</summary>
        [JsonPropertyName("side")]
        public PoloniexTradeSide Side { get; set; }
        /// <summary>[<c>type</c>] Execution type.</summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        /// <summary>[<c>mgnMode</c>] Margin mode.</summary>
        [JsonPropertyName("mgnMode")]
        public PoloniexFuturesMarginMode MarginMode { get; set; }
        /// <summary>[<c>posSide</c>] Position side.</summary>
        [JsonPropertyName("posSide")]
        public PoloniexFuturesPositionSide PositionSide { get; set; }
        /// <summary>[<c>ordType</c>] Order type.</summary>
        [JsonPropertyName("ordType")]
        public PoloniexOrderType OrderType { get; set; }
        /// <summary>[<c>role</c>] Maker or taker role.</summary>
        [JsonPropertyName("role")]
        public PoloniexTradeMatchRole Role { get; set; }
        /// <summary>[<c>px</c>] REST execution price.</summary>
        [JsonPropertyName("px")]
        public decimal Price { get; set; }
        /// <summary>[<c>qty</c>] REST execution quantity in contracts.</summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>[<c>fpx</c>] WebSocket execution price.</summary>
        [JsonPropertyName("fpx")]
        public decimal FillPrice { get; set; }
        /// <summary>[<c>fqty</c>] WebSocket execution quantity in contracts.</summary>
        [JsonPropertyName("fqty")]
        public decimal FillQuantity { get; set; }
        /// <summary>[<c>value</c>] Trade value.</summary>
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
        /// <summary>[<c>feeCcy</c>] Fee currency.</summary>
        [JsonPropertyName("feeCcy")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>[<c>feeAmt</c>] Fee amount.</summary>
        [JsonPropertyName("feeAmt")]
        public decimal FeeAmount { get; set; }
        /// <summary>[<c>deductCcy</c>] Fee deduction currency.</summary>
        [JsonPropertyName("deductCcy")]
        public string DeductAsset { get; set; } = string.Empty;
        /// <summary>[<c>deductAmt</c>] Deducted fee amount.</summary>
        [JsonPropertyName("deductAmt")]
        public decimal DeductAmount { get; set; }
        /// <summary>[<c>feeRate</c>] Fee rate.</summary>
        [JsonPropertyName("feeRate")]
        public decimal FeeRate { get; set; }
        /// <summary>[<c>actType</c>] Account type.</summary>
        [JsonPropertyName("actType")]
        public string AccountType { get; set; } = string.Empty;
        /// <summary>[<c>qCcy</c>] Quote currency.</summary>
        [JsonPropertyName("qCcy")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>[<c>cTime</c>] Execution time.</summary>
        [JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>[<c>uTime</c>] Update time.</summary>
        [JsonPropertyName("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>[<c>ts</c>] Push time.</summary>
        [JsonPropertyName("ts"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Timestamp { get; set; }
    }
}
