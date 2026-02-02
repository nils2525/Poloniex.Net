using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexAccountBalance
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; } = string.Empty;

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; } = string.Empty;

        [JsonPropertyName("balances")]
        public List<PoloniexAccountBalanceEntry> Balances { get; set; } = new();

    }

    public class PoloniexAccountBalanceEntry
    {
        [JsonPropertyName("currencyId")]
        public string CurrencyId { get; set; } = string.Empty;

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("available")]
        public decimal Available { get; set; }

        [JsonPropertyName("hold")]
        public decimal Hold { get; set; }
    }
}