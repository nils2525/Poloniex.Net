using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures account position mode.</summary>
    public class PoloniexFuturesPositionModeInfo
    {
        /// <summary>[<c>posMode</c>] Active position mode.</summary>
        [JsonPropertyName("posMode")]
        public PoloniexFuturesPositionMode PositionMode { get; set; }
    }
}
