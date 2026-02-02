using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexOrderType>))]
    public enum PoloniexOrderType
    {
        [Map("LIMIT")]
        Limit,

        [Map("MARKET")]
        Market,

        [Map("LIMIT_MAKER")]
        LimitMaker,
    }
}
