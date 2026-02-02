using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexPageDirection>))]
    public enum PoloniexPageDirection
    {
        [Map("PRE")]
        Previous,

        [Map("NEXT")]
        Next
    }
}
