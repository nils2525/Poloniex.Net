using System.Text.Json.Serialization;
using Poloniex.Net.Enums;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexWithdrawal
    {
        [JsonPropertyName("withdrawalRequestsId")]
        public long Id { get; set; }

        [JsonPropertyName("currency")]
        public string Asset { get; set; } = string.Empty;

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("fee")]
        public decimal Fee { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("status")]
        public PoloniexWithdrawalStatus Status { get; set; }

        [JsonPropertyName("txid")]
        public string TransactionId { get; set; } = string.Empty;

        [JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; } = string.Empty;

        [JsonPropertyName("paymentID")]
        public string PaymentId { get; set; } = string.Empty;
    }
}
