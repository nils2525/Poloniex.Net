using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures position information.</summary>
    public class PoloniexFuturesPosition
    {
        /// <summary>[<c>symbol</c>] Trading pair.</summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>[<c>side</c>] Trade side that opened the position.</summary>
        [JsonPropertyName("side")]
        public PoloniexTradeSide Side { get; set; }
        /// <summary>[<c>mgnMode</c>] Margin mode.</summary>
        [JsonPropertyName("mgnMode")]
        public PoloniexFuturesMarginMode MarginMode { get; set; }
        /// <summary>[<c>posSide</c>] Position side.</summary>
        [JsonPropertyName("posSide")]
        public PoloniexFuturesPositionSide PositionSide { get; set; }
        /// <summary>[<c>openAvgPx</c>] Average entry price.</summary>
        [JsonPropertyName("openAvgPx")]
        public decimal AverageOpenPrice { get; set; }
        /// <summary>[<c>qty</c>] Position quantity in contracts.</summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>[<c>oldQty</c>] Previous position quantity in contracts.</summary>
        [JsonPropertyName("oldQty")]
        public decimal PreviousQuantity { get; set; }
        /// <summary>[<c>availQty</c>] Quantity available to close.</summary>
        [JsonPropertyName("availQty")]
        public decimal AvailableQuantity { get; set; }
        /// <summary>[<c>lever</c>] Leverage.</summary>
        [JsonPropertyName("lever")]
        public decimal Leverage { get; set; }
        /// <summary>[<c>adl</c>] Auto-deleveraging indicator.</summary>
        [JsonPropertyName("adl")]
        public decimal AutoDeleveraging { get; set; }
        /// <summary>[<c>liqPx</c>] Estimated liquidation price.</summary>
        [JsonPropertyName("liqPx")]
        public decimal LiquidationPrice { get; set; }
        /// <summary>[<c>im</c>] Initial margin.</summary>
        [JsonPropertyName("im")]
        public decimal InitialMargin { get; set; }
        /// <summary>[<c>mm</c>] Maintenance margin.</summary>
        [JsonPropertyName("mm")]
        public decimal MaintenanceMargin { get; set; }
        /// <summary>[<c>mgn</c>] Isolated position margin.</summary>
        [JsonPropertyName("mgn")]
        public decimal Margin { get; set; }
        /// <summary>[<c>maxWAmt</c>] Maximum isolated margin withdrawal.</summary>
        [JsonPropertyName("maxWAmt")]
        public decimal MaximumWithdrawalAmount { get; set; }
        /// <summary>[<c>upl</c>] Unrealized profit and loss.</summary>
        [JsonPropertyName("upl")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>[<c>uplRatio</c>] Unrealized profit-and-loss ratio.</summary>
        [JsonPropertyName("uplRatio")]
        public decimal UnrealizedPnlRatio { get; set; }
        /// <summary>[<c>pnl</c>] Realized profit and loss.</summary>
        [JsonPropertyName("pnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>[<c>fpnl</c>] Latest closing profit and loss.</summary>
        [JsonPropertyName("fpnl")]
        public decimal LatestClosingPnl { get; set; }
        /// <summary>[<c>fee</c>] Position closing fee.</summary>
        [JsonPropertyName("fee")]
        public decimal ClosingFee { get; set; }
        /// <summary>[<c>ffee</c>] Latest funding fee.</summary>
        [JsonPropertyName("ffee")]
        public decimal FundingFee { get; set; }
        /// <summary>[<c>markPx</c>] Mark price.</summary>
        [JsonPropertyName("markPx")]
        public decimal MarkPrice { get; set; }
        /// <summary>[<c>lastPx</c>] Last price.</summary>
        [JsonPropertyName("lastPx")]
        public decimal LastPrice { get; set; }
        /// <summary>[<c>indexPx</c>] Index price.</summary>
        [JsonPropertyName("indexPx")]
        public decimal IndexPrice { get; set; }
        /// <summary>[<c>mgnRatio</c>] Margin ratio.</summary>
        [JsonPropertyName("mgnRatio")]
        public decimal MarginRatio { get; set; }
        /// <summary>[<c>state</c>] Position state.</summary>
        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;
        /// <summary>[<c>actType</c>] Account type.</summary>
        [JsonPropertyName("actType")]
        public string AccountType { get; set; } = string.Empty;
        /// <summary>[<c>tpTrgPx</c>] Take-profit trigger price.</summary>
        [JsonPropertyName("tpTrgPx")]
        public decimal? TakeProfitTriggerPrice { get; set; }
        /// <summary>[<c>slTrgPx</c>] Stop-loss trigger price.</summary>
        [JsonPropertyName("slTrgPx")]
        public decimal? StopLossTriggerPrice { get; set; }
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
