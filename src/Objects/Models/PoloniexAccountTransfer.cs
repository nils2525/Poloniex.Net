using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>Account transfer result.</summary>
    public class PoloniexAccountTransfer
    {
        /// <summary>[<c>transferId</c>] Transfer identifier.</summary>
        [JsonPropertyName("transferId")]
        public string TransferId { get; set; } = string.Empty;
    }
}
