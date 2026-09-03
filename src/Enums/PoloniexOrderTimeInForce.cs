using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Enums
{
    /// <summary>Order time-in-force policy.</summary>
    [JsonConverter(typeof(EnumConverter<PoloniexOrderTimeInForce>))]
    public enum PoloniexOrderTimeInForce
    {
        /// <summary>[<c>GTC</c>] Good until canceled.</summary>
        [Map("GTC")]
        GoodTillCanceled,

        /// <summary>[<c>IOC</c>] Execute immediately and cancel the remainder.</summary>
        [Map("IOC")]
        ImmediateOrCancel,

        /// <summary>[<c>FOK</c>] Fill the complete order immediately or cancel it.</summary>
        [Map("FOK")]
        FillOrKill,
    }
}
