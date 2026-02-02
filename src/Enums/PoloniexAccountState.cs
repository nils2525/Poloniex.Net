using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexAccountState>))]
    public enum PoloniexAccountState
    {
        [Map("NORMAL")]
        Normal,

        [Map("LOCKED")]
        Locked
    }
}
