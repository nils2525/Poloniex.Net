using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexDepositStatus>))]
    public enum PoloniexDepositStatus
    {
        [Map("PENDING")]
        Pending,

        [Map("COMPLETED")]
        Completed
    }
}
