using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures order information.</summary>
    public class PoloniexFuturesOrder : PoloniexFuturesOrderId
    {
        /// <summary>[<c>symbol</c>] Trading pair.</summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>[<c>side</c>] Order side.</summary>
        [JsonPropertyName("side")]
        public PoloniexTradeSide Side { get; set; }
        /// <summary>[<c>type</c>] Order type.</summary>
        [JsonPropertyName("type")]
        public PoloniexOrderType Type { get; set; }
        /// <summary>[<c>mgnMode</c>] Margin mode.</summary>
        [JsonPropertyName("mgnMode")]
        public PoloniexFuturesMarginMode MarginMode { get; set; }
        /// <summary>[<c>posSide</c>] Position side.</summary>
        [JsonPropertyName("posSide")]
        public PoloniexFuturesPositionSide PositionSide { get; set; }
        /// <summary>[<c>px</c>] Order price.</summary>
        [JsonPropertyName("px")]
        public decimal Price { get; set; }
        /// <summary>[<c>sz</c>] Order quantity in contracts.</summary>
        [JsonPropertyName("sz")]
        public decimal Quantity { get; set; }
        /// <summary>[<c>state</c>] Order state.</summary>
        [JsonPropertyName("state")]
        public PoloniexOrderState State { get; set; }
        /// <summary>[<c>cancelReason</c>] Cancellation reason.</summary>
        [JsonPropertyName("cancelReason")]
        public string? CancelReason { get; set; }
        /// <summary>[<c>source</c>] Order source.</summary>
        [JsonPropertyName("source")]
        public string Source { get; set; } = string.Empty;
        /// <summary>[<c>reduceOnly</c>] Whether the order only reduces a position.</summary>
        [JsonPropertyName("reduceOnly")]
        public bool ReduceOnly { get; set; }
        /// <summary>[<c>timeInForce</c>] Time-in-force policy.</summary>
        [JsonPropertyName("timeInForce")]
        public PoloniexOrderTimeInForce TimeInForce { get; set; }
        /// <summary>[<c>lever</c>] Leverage.</summary>
        [JsonPropertyName("lever")]
        public decimal Leverage { get; set; }
        /// <summary>[<c>avgPx</c>] Average execution price.</summary>
        [JsonPropertyName("avgPx")]
        public decimal AveragePrice { get; set; }
        /// <summary>[<c>execQty</c>] Cumulative executed quantity in contracts.</summary>
        [JsonPropertyName("execQty")]
        public decimal ExecutedQuantity { get; set; }
        /// <summary>[<c>execAmt</c>] Cumulative executed value.</summary>
        [JsonPropertyName("execAmt")]
        public decimal ExecutedValue { get; set; }
        /// <summary>[<c>feeCcy</c>] Fee currency.</summary>
        [JsonPropertyName("feeCcy")]
        public string FeeAsset { get; set; } = string.Empty;
        /// <summary>[<c>feeAmt</c>] Cumulative fee amount.</summary>
        [JsonPropertyName("feeAmt")]
        public decimal FeeAmount { get; set; }
        /// <summary>[<c>deductCcy</c>] Fee deduction currency.</summary>
        [JsonPropertyName("deductCcy")]
        public string DeductAsset { get; set; } = string.Empty;
        /// <summary>[<c>deductAmt</c>] Deducted fee amount.</summary>
        [JsonPropertyName("deductAmt")]
        public decimal DeductAmount { get; set; }
        /// <summary>[<c>fillSz</c>] Last fill quantity in contracts.</summary>
        [JsonPropertyName("fillSz")]
        public decimal LastFillQuantity { get; set; }
        /// <summary>[<c>actType</c>] Account type.</summary>
        [JsonPropertyName("actType")]
        public string AccountType { get; set; } = string.Empty;
        /// <summary>[<c>qCcy</c>] Quote currency.</summary>
        [JsonPropertyName("qCcy")]
        public string QuoteAsset { get; set; } = string.Empty;
        /// <summary>[<c>stpMode</c>] Self-trade prevention mode.</summary>
        [JsonPropertyName("stpMode")]
        public string SelfTradePreventionMode { get; set; } = string.Empty;
        /// <summary>[<c>tpTrgPx</c>] Take-profit trigger price.</summary>
        [JsonPropertyName("tpTrgPx")]
        public decimal? TakeProfitTriggerPrice { get; set; }
        /// <summary>[<c>tpPx</c>] Take-profit order price.</summary>
        [JsonPropertyName("tpPx")]
        public decimal? TakeProfitPrice { get; set; }
        /// <summary>[<c>tpTrgPxType</c>] Take-profit trigger price type.</summary>
        [JsonPropertyName("tpTrgPxType")]
        public string? TakeProfitTriggerPriceType { get; set; }
        /// <summary>[<c>slTrgPx</c>] Stop-loss trigger price.</summary>
        [JsonPropertyName("slTrgPx")]
        public decimal? StopLossTriggerPrice { get; set; }
        /// <summary>[<c>slPx</c>] Stop-loss order price.</summary>
        [JsonPropertyName("slPx")]
        public decimal? StopLossPrice { get; set; }
        /// <summary>[<c>slTrgPxType</c>] Stop-loss trigger price type.</summary>
        [JsonPropertyName("slTrgPxType")]
        public string? StopLossTriggerPriceType { get; set; }
        /// <summary>[<c>cTime</c>] Creation time.</summary>
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
