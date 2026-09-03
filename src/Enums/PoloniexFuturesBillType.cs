using CryptoExchange.Net.Attributes;
using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Enums
{
    /// <summary>Futures account bill type.</summary>
    [JsonConverter(typeof(EnumConverter<PoloniexFuturesBillType>))]
    public enum PoloniexFuturesBillType
    {
        /// <summary>Trading fee.</summary>
        [Map("FEE")]
        Fee,

        /// <summary>Realized profit and loss.</summary>
        [Map("PNL")]
        Pnl,

        /// <summary>Manual isolated-margin adjustment.</summary>
        [Map("MANUAL_MARGIN")]
        ManualMargin,

        /// <summary>Transfer into or out of the Futures account.</summary>
        [Map("TRANSFER")]
        Transfer,

        /// <summary>Trial-fund income.</summary>
        [Map("TRIAL_INCOME")]
        TrialIncome,

        /// <summary>Coupon credit.</summary>
        [Map("COUPON")]
        Coupon,

        /// <summary>Liquidation profit and loss.</summary>
        [Map("LIQ_PNL")]
        LiquidationPnl,

        /// <summary>Auto-deleveraging profit and loss.</summary>
        [Map("ADL_PNL")]
        AutoDeleveragingPnl,

        /// <summary>Funding payment.</summary>
        [Map("FUNDING_FEE")]
        FundingFee,
    }
}
