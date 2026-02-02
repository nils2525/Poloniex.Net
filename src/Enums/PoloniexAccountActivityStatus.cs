using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexAccountActivityStatus>))]
    public enum PoloniexAccountActivityStatus
    {
        [Map("SUCCESS")]
        Success,

        [Map("PROCESSING")]
        Processing,

        [Map("FAILED")]
        Failed
    }
}
