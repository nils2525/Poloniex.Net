using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexAccount
    {
        /// <summary>[<c>accountId</c>] Account identifier when supplied.</summary>
        [JsonPropertyName("accountId")]
        public string? AccountId { get; set; }

        /// <summary>[<c>accountType</c>] Account type when supplied.</summary>
        [JsonPropertyName("accountType")]
        public string? AccountType { get; set; }

        [JsonPropertyName("accountState")]
        public PoloniexAccountState AccountState { get; set; }
    }
}
