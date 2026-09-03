using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Enums
{
    /// <summary>Futures margin mode.</summary>
    [JsonConverter(typeof(EnumConverter<PoloniexFuturesMarginMode>))]
    public enum PoloniexFuturesMarginMode
    {
        /// <summary>[<c>CROSS</c>] Cross margin.</summary>
        [Map("CROSS")]
        Cross,

        /// <summary>[<c>ISOLATED</c>] Isolated margin.</summary>
        [Map("ISOLATED")]
        Isolated,
    }
}
