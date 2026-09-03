using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures account balance.</summary>
    public class PoloniexFuturesAccountBalance
    {
        /// <summary>[<c>state</c>] Account state.</summary>
        [JsonPropertyName("state")]
        public string State { get; set; } = string.Empty;
        /// <summary>[<c>eq</c>] Total account equity.</summary>
        [JsonPropertyName("eq")]
        public decimal Equity { get; set; }
        /// <summary>[<c>isoEq</c>] Isolated-position equity.</summary>
        [JsonPropertyName("isoEq")]
        public decimal IsolatedEquity { get; set; }
        /// <summary>[<c>im</c>] Initial margin.</summary>
        [JsonPropertyName("im")]
        public decimal InitialMargin { get; set; }
        /// <summary>[<c>mm</c>] Maintenance margin.</summary>
        [JsonPropertyName("mm")]
        public decimal MaintenanceMargin { get; set; }
        /// <summary>[<c>mmr</c>] Maintenance margin rate.</summary>
        [JsonPropertyName("mmr")]
        public decimal MaintenanceMarginRate { get; set; }
        /// <summary>[<c>upl</c>] Cross-margin unrealized profit and loss.</summary>
        [JsonPropertyName("upl")]
        public decimal UnrealizedPnl { get; set; }
        /// <summary>[<c>availMgn</c>] Available margin.</summary>
        [JsonPropertyName("availMgn")]
        public decimal AvailableMargin { get; set; }
        /// <summary>[<c>cTime</c>] Creation time.</summary>
        [JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>[<c>uTime</c>] Update time.</summary>
        [JsonPropertyName("uTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime UpdateTime { get; set; }
        /// <summary>[<c>ts</c>] Event timestamp.</summary>
        [JsonPropertyName("ts"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime? Timestamp { get; set; }
        /// <summary>[<c>details</c>] Per-currency balances.</summary>
        [JsonPropertyName("details")]
        public PoloniexFuturesAccountBalanceDetail[] Details { get; set; } = [];
    }
}
