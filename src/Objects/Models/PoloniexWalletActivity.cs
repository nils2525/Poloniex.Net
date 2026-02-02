using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexWalletActivity
    {
        [JsonPropertyName("deposits")]
        public PoloniexDeposit[] Deposits { get; set; } = [];

        [JsonPropertyName("withdrawals")]
        public PoloniexWithdrawal[] Withdrawals { get; set; } = [];
    }
}
