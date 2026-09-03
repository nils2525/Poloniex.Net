using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Enums
{
    /// <summary>Futures position mode.</summary>
    [JsonConverter(typeof(EnumConverter<PoloniexFuturesPositionMode>))]
    public enum PoloniexFuturesPositionMode
    {
        /// <summary>[<c>ONE_WAY</c>] One-way position mode.</summary>
        [Map("ONE_WAY")]
        OneWay,

        /// <summary>[<c>HEDGE</c>] Independent long and short positions.</summary>
        [Map("HEDGE")]
        Hedge,
    }
}
