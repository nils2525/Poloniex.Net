using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexWalletActivityType>))]
    public enum PoloniexWalletActivityType
    {
        [Map("deposits")]
        Deposits,

        [Map("withdrawals")]
        Withdrawals
    }
}
