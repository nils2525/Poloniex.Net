using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexAccountActivityDirection>))]
    public enum PoloniexAccountActivityDirection
    {
        [Map("PRE")]
        Previous,

        [Map("NEXT")]
        Next
    }
}
