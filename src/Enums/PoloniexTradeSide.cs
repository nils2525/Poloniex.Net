using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexTradeSide>))]
    public enum PoloniexTradeSide
    {
        [Map("buy", "BUY")]
        Buy,

        [Map("sell", "SELL")]
        Sell
    }
}
