using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexAccountFee
    {
        [JsonPropertyName("trxDiscount")]
        public bool TRXDiscount { get; set; }

        [JsonPropertyName("makerRate")]
        public decimal MakerRate { get; set; }

        [JsonPropertyName("takerRate")]
        public decimal TakerRate { get; set; }

        [JsonPropertyName("volume30D")]
        public decimal Volume30D { get; set; }

        [JsonPropertyName("specialFeeRates")]
        public List<PoloniexAccountFeeSpecial> SpecialFeeRates { get; set; } = new();
    }

    public class PoloniexAccountFeeSpecial
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("makerRate")]
        public decimal MakerRate { get; set; }

        [JsonPropertyName("takerRate")]
        public decimal TakerRate { get; set; }
    }
}
