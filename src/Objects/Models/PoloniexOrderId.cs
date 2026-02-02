using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexOrderId
    {
        [JsonPropertyName("id")]
        public string OrderId { get; set; } = string.Empty;

        [JsonPropertyName("clientOrderId")]
        public string? ClientOrderId { get; set; }
    }
}
