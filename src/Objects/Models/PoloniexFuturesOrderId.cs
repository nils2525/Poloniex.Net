using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Futures order identifiers.</summary>
    public class PoloniexFuturesOrderId
    {
        /// <summary>[<c>ordId</c>] Exchange order identifier.</summary>
        [JsonPropertyName("ordId")]
        public string OrderId { get; set; } = string.Empty;

        /// <summary>[<c>clOrdId</c>] Client order identifier.</summary>
        [JsonPropertyName("clOrdId")]
        public string? ClientOrderId { get; set; }
    }
}
