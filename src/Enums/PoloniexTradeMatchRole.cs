using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexTradeMatchRole>))]
    public enum PoloniexTradeMatchRole
    {
        [Map("MAKER")]
        Maker,

        [Map("TAKER")]
        Taker
    }
}
