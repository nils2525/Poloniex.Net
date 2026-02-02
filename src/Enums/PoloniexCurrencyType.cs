using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexCurrencyType>))]
    public enum PoloniexCurrencyType
    {
        [Map("mimblewimble")]
        Unknown,

        [Map("address")]
        Address,

        [Map("address-payment-id")]
        AddressPaymentId,
    }
}
