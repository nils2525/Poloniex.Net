using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexOrderState>))]
    public enum PoloniexOrderState
    {
        [Map("NEW")]
        New,

        [Map("PARTIALLY_FILLED")]
        PartiallyFilled,

        [Map("FILLED")]
        Filled,

        [Map("PENDING_CANCEL")]
        PendingCancel,

        [Map("PARTIALLY_CANCELED")]
        PartiallyCanceled,

        [Map("CANCELED")]
        Canceled,

        [Map("FAILED")]
        Failed,
    }
}
