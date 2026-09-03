using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Historical Futures position.</summary>
    public class PoloniexFuturesPositionHistory
    {
        /// <summary>[<c>id</c>] Pagination and position identifier.</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>[<c>symbol</c>] Trading pair.</summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>[<c>side</c>] Side that opened the position.</summary>
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
        /// <summary>[<c>closeAvgPx</c>] Average closing price.</summary>
        [JsonPropertyName("closeAvgPx")]
        public decimal AverageClosePrice { get; set; }
        /// <summary>[<c>qty</c>] Position quantity after the final execution.</summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }
        /// <summary>[<c>closedQty</c>] Signed closed quantity.</summary>
        [JsonPropertyName("closedQty")]
        public decimal ClosedQuantity { get; set; }
        /// <summary>[<c>availQty</c>] Quantity still available to close.</summary>
        [JsonPropertyName("availQty")]
        public decimal AvailableQuantity { get; set; }
        /// <summary>[<c>pnl</c>] Cumulative realized profit and loss.</summary>
        [JsonPropertyName("pnl")]
        public decimal RealizedPnl { get; set; }
        /// <summary>[<c>fee</c>] Cumulative trading fee.</summary>
        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }
        /// <summary>[<c>fFee</c>] Cumulative funding charge.</summary>
        [JsonPropertyName("fFee")]
        public decimal FundingFee { get; set; }
        /// <summary>[<c>state</c>] Position state, for example <c>NORMAL</c>, <c>LIQUIDATION</c>, or <c>ADL</c>.</summary>
        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;
        /// <summary>[<c>cTime</c>] Position creation time.</summary>
        [JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>[<c>uTime</c>] Position update time.</summary>
        [JsonPropertyName("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
    }
}
