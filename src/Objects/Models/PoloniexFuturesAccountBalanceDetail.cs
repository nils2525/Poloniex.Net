using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures balance for one currency.</summary>
    public class PoloniexFuturesAccountBalanceDetail
    {
        /// <summary>[<c>ccy</c>] Currency.</summary>
        [JsonPropertyName("ccy")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>[<c>eq</c>] Currency equity.</summary>
        [JsonPropertyName("eq")]
        public decimal Equity { get; set; }
        /// <summary>[<c>isoEq</c>] Isolated-position equity.</summary>
        [JsonPropertyName("isoEq")]
        public decimal IsolatedEquity { get; set; }
        /// <summary>[<c>avail</c>] Available cross balance.</summary>
        [JsonPropertyName("avail")]
        public decimal Available { get; set; }
        /// <summary>[<c>trdHold</c>] Cross balance held for trading.</summary>
        [JsonPropertyName("trdHold")]
        public decimal TradingHold { get; set; }
        /// <summary>[<c>upl</c>] Unrealized profit and loss.</summary>
        [JsonPropertyName("upl")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>[<c>isoAvail</c>] Available isolated margin.</summary>
        [JsonPropertyName("isoAvail")]
        public decimal IsolatedAvailable { get; set; }
        /// <summary>[<c>isoHold</c>] Isolated-order hold.</summary>
        [JsonPropertyName("isoHold")]
        public decimal IsolatedHold { get; set; }
        /// <summary>[<c>isoUpl</c>] Isolated-position unrealized profit and loss.</summary>
        [JsonPropertyName("isoUpl")]
        public decimal IsolatedUnrealizedPnl { get; set; }
        /// <summary>[<c>im</c>] Initial margin.</summary>
        [JsonPropertyName("im")]
        public decimal InitialMargin { get; set; }
        /// <summary>[<c>mm</c>] Maintenance margin.</summary>
        [JsonPropertyName("mm")]
        public decimal MaintenanceMargin { get; set; }
        /// <summary>[<c>mmr</c>] Maintenance margin rate.</summary>
        [JsonPropertyName("mmr")]
        public decimal MaintenanceMarginRate { get; set; }
        /// <summary>[<c>imr</c>] Initial margin rate.</summary>
        [JsonPropertyName("imr")]
        public decimal InitialMarginRate { get; set; }
        /// <summary>[<c>cTime</c>] Creation time.</summary>
        [JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>[<c>uTime</c>] Update time.</summary>
        [JsonPropertyName("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
    }
}
