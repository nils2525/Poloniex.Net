using System.Text.Json.Serialization;
using Poloniex.Net.Enums;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexDeposit
    {
        [JsonPropertyName("depositNumber")]
        public long Id { get; set; }

        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("confirmations")]
        public int Confirmations { get; set; }

        [JsonPropertyName("txid")]
        public string TransactionId { get; set; } = string.Empty;

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("status")]
        public PoloniexDepositStatus Status { get; set; }

    }
}
