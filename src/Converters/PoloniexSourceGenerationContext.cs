using System.Text.Json.Serialization;
using Poloniex.Net.Objects.Internal;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Converters
{
    [JsonSerializable(typeof(PoloniexTimestamp))]
    [JsonSerializable(typeof(PoloniexAccount[]))]
    [JsonSerializable(typeof(PoloniexAccountBalance[]))]
    [JsonSerializable(typeof(PoloniexCurrency[]))]
    [JsonSerializable(typeof(PoloniexSymbol[]))]
    [JsonSerializable(typeof(PoloniexTicker))]
    [JsonSerializable(typeof(PoloniexTicker[]))]
    [JsonSerializable(typeof(PoloniexAccountFee))]
    [JsonSerializable(typeof(PoloniexSocketRequest))]
    [JsonSerializable(typeof(PoloniexSocketResponse<PoloniexSocketAuthResponse>))]
    [JsonSerializable(typeof(PoloniexSocketSubscriptionResponse))]
    [JsonSerializable(typeof(PoloniexSubscriptionEvent<PoloniexOrderBook>))]
    [JsonSerializable(typeof(PoloniexSubscriptionEvent<PoloniexTrade>))]
    [JsonSerializable(typeof(PoloniexSubscriptionEvent<PoloniexCandle>))]
    [JsonSerializable(typeof(PoloniexSubscriptionEvent<PoloniexOrderUpdate>))]
    [JsonSerializable(typeof(PoloniexSubscriptionEvent<PoloniexBalanceUpdate>))]
    [JsonSerializable(typeof(IDictionary<string, object>))]
    [JsonSerializable(typeof(int?))]
    [JsonSerializable(typeof(PoloniexOrderId))]
    [JsonSerializable(typeof(PoloniexCancelOrderResult))]
    [JsonSerializable(typeof(PoloniexOrder[]))]
    [JsonSerializable(typeof(PoloniexOrderTrade[]))]
    [JsonSerializable(typeof(PoloniexWalletActivity))]
    [JsonSerializable(typeof(PoloniexAccountActivity[]))]
    internal partial class PoloniexSourceGenerationContext : JsonSerializerContext
    { }
}
