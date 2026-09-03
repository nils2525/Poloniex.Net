using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures leverage configuration.</summary>
    public class PoloniexFuturesLeverage
    {
        /// <summary>[<c>symbol</c>] Trading pair.</summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>[<c>mgnMode</c>] Margin mode.</summary>
        [JsonPropertyName("mgnMode")]
        public PoloniexFuturesMarginMode MarginMode { get; set; }
        /// <summary>[<c>posSide</c>] Position side.</summary>
        [JsonPropertyName("posSide")]
        public PoloniexFuturesPositionSide PositionSide { get; set; }
        /// <summary>[<c>lever</c>] Leverage.</summary>
        [JsonPropertyName("lever")]
        public decimal Leverage { get; set; }
    }
}
