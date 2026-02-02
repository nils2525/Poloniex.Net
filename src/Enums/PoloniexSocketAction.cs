using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexSocketAction>))]
    public enum PoloniexSocketAction
    {
        [Map("update")]
        Update,

        [Map("snapshot")]
        Snapshot,
    }
}
