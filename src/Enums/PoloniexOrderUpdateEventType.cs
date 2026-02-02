using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexOrderUpdateEventType>))]
    public enum PoloniexOrderUpdateEventType
    {
        [Map("place")]
        Place,

        [Map("trade")]
        Trade,

        [Map("cancel")]
        Canceled
    }
}
