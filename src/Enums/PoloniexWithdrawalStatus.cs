using System.Text.Json.Serialization;
using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;

namespace Poloniex.Net.Enums
{
    [JsonConverter(typeof(EnumConverter<PoloniexWithdrawalStatus>))]
    public enum PoloniexWithdrawalStatus
    {
        [Map("PROCESSING")]
        Processing,

        [Map("AWAITING APPROVAL")]
        AwaitingApproval,

        [Map("COMPLETED")]
        Completed,

        [Map("COMPLETED ERROR")]
        CompletedError
    }
}
