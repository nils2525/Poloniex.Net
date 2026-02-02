using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;

namespace Poloniex.Net.Objects.Models
{
    [JsonConverter(typeof(ArrayConverter<PoloniexOrderBookEntry>))]
    public class PoloniexOrderBookEntry : ISymbolOrderBookEntry
    {
        [ArrayProperty(0)]
        public decimal Price { get; set; }

        [ArrayProperty(1)]
        public decimal Quantity { get; set; }
    }
}
