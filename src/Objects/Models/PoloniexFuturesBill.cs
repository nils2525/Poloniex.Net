using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures account bill.</summary>
    public class PoloniexFuturesBill
    {
        /// <summary>[<c>id</c>] Pagination and bill identifier.</summary>
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        /// <summary>[<c>actType</c>] Account type, for example <c>TRADING</c> or <c>TRIAL</c>.</summary>
        [JsonPropertyName("actType")]
        public string AccountType { get; set; } = string.Empty;
        /// <summary>[<c>symbol</c>] Trading pair; empty for account-wide entries such as transfers.</summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>[<c>mgnMode</c>] Margin mode; empty for account-wide entries such as transfers.</summary>
        [JsonPropertyName("mgnMode")]
        public string MarginMode { get; set; } = string.Empty;
        /// <summary>[<c>posSide</c>] Position side; empty for account-wide entries such as transfers.</summary>
        [JsonPropertyName("posSide")]
        public string PositionSide { get; set; } = string.Empty;
        /// <summary>[<c>ccy</c>] Currency.</summary>
        [JsonPropertyName("ccy")]
        public string Asset { get; set; } = string.Empty;
        /// <summary>[<c>sz</c>] Signed bill amount.</summary>
        [JsonPropertyName("sz")]
        public decimal Quantity { get; set; }
        /// <summary>[<c>cTime</c>] Bill creation time.</summary>
        [JsonPropertyName("cTime"), JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreateTime { get; set; }
        /// <summary>[<c>type</c>] Bill type.</summary>
        [JsonPropertyName("type")]
        public PoloniexFuturesBillType Type { get; set; }
    }
}
