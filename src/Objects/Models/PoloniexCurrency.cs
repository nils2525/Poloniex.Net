using Poloniex.Net.Enums;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexCurrency
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("coin")]
        public string Coin { get; set; } = string.Empty;

        [JsonPropertyName("delisted")]
        public bool Delisted { get; set; }

        [JsonPropertyName("tradeEnable")]
        public bool TradeEnable { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("supportCollateral")]
        public bool SupportCollateral { get; set; }

        [JsonPropertyName("supportBorrow")]
        public bool SupportBorrow { get; set; }

        [JsonPropertyName("networkList")]
        public List<PoloniexCurrencyNetwork> Networks { get; set; } = new List<PoloniexCurrencyNetwork>();
    }

    public class PoloniexCurrencyNetwork
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("coin")]
        public string Coin { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("currencyType")]
        public PoloniexCurrencyType CurrencyType { get; set; }

        [JsonPropertyName("blockchain")]
        public string Blockchain { get; set; } = string.Empty;

        [JsonPropertyName("withdrawalEnable")]
        public bool WithdrawalEnable { get; set; }

        [JsonPropertyName("depositEnable")]
        public bool DepositEnable { get; set; }

        [JsonPropertyName("depositAddress")]
        public string? DepositAddress { get; set; }

        [JsonPropertyName("withdrawMin")]
        public decimal? WithdrawMin { get; set; }

        [JsonPropertyName("minConfirm")]
        public int MinConfirm { get; set; }
    }
}
