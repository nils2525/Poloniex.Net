using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexSymbolState>))]
    public enum PoloniexSymbolState
    {
        [Map("NORMAL")]
        Normal,

        [Map("PAUSE")]
        Pause,

        [Map("POST_ONLY")]
        PostOnlys
    }
}
