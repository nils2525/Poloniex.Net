using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexAccountActivityType>))]
    public enum PoloniexAccountActivityType
    {
        [Map("200")]
        All = 200,

        [Map("201")]
        Airdrop = 201,

        [Map("202")]
        CommissionRebate = 202,

        [Map("203")]
        Staking = 203,

        [Map("204")]
        ReferalRebate = 204,

        [Map("205")]
        Swap = 205,

        [Map("104")]
        CreditAdjustment = 104,

        [Map("105")]
        DebitAdjustment = 105,

        [Map("199")]
        Other = 199
    }
}
