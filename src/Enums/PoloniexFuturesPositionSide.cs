using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Enums
{
    /// <summary>Futures position side.</summary>
    [JsonConverter(typeof(EnumConverter<PoloniexFuturesPositionSide>))]
    public enum PoloniexFuturesPositionSide
    {
        /// <summary>[<c>BOTH</c>] Net position used by one-way mode.</summary>
        [Map("BOTH")]
        Both,

        /// <summary>[<c>LONG</c>] Long side in hedge mode.</summary>
        [Map("LONG")]
        Long,

        /// <summary>[<c>SHORT</c>] Short side in hedge mode.</summary>
        [Map("SHORT")]
        Short,
    }
}
