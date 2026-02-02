using CryptoExchange.Net;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.RateLimiting;
using CryptoExchange.Net.RateLimiting.Filters;
using CryptoExchange.Net.RateLimiting.Guards;
using CryptoExchange.Net.RateLimiting.Interfaces;
using CryptoExchange.Net.SharedApis;
using Poloniex.Net.Converters;

namespace Poloniex.Net
{
    /// <summary>
    /// CryptoCom exchange information and configuration
    /// </summary>
    public static class PoloniexExchange
    {
        internal static PoloniexSourceGenerationContext SerializerContext { get; } = new();

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string ExchangeName => "Poloniex";

        /// <summary>
        /// Exchange name
        /// </summary>
        public static string DisplayName => "Poloniex.com";

        /// <summary>
        /// Url to exchange image
        /// </summary>
        public static string ImageUrl { get; } = "https://api-docs.poloniex.com/img/polo-icon-32x32.png";

        /// <summary>
        /// Url to the main website
        /// </summary>
        public static string Url { get; } = "https://www.poloniex.com";

        /// <summary>
        /// Urls to the API documentation
        /// </summary>
        public static string[] ApiDocsUrl { get; } = new[] {
            "https://api-docs.poloniex.com/spot/api/"
            };

        /// <summary>
        /// Type of exchange
        /// </summary>
        public static ExchangeType Type { get; } = ExchangeType.CEX;

        /// <summary>
        /// Format a base and quote asset to a Crypto.com recognized symbol 
        /// </summary>
        /// <param name="baseAsset">Base asset</param>
        /// <param name="quoteAsset">Quote asset</param>
        /// <param name="tradingMode">Trading mode</param>
        /// <param name="deliverTime">Delivery time for delivery futures</param>
        /// <returns></returns>
        public static string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
        {
            if (tradingMode == TradingMode.Spot)
                return $"{baseAsset.ToUpperInvariant()}_{quoteAsset.ToUpperInvariant()}";

            if (tradingMode.IsPerpetual())
                return $"{baseAsset.ToUpperInvariant()}{quoteAsset.ToUpperInvariant()}-PERP";

            if (deliverTime == null)
                throw new ArgumentException("DeliverDate required to format delivery futures symbol");

            return $"{baseAsset.ToUpperInvariant()}{quoteAsset.ToUpperInvariant()}-{deliverTime.Value.ToString("yyMMdd")}";
        }

        /// <summary>
        /// Rate limiter configuration for the CryptoCom API
        /// </summary>
        public static CryptoComRateLimiters RateLimiter { get; } = new CryptoComRateLimiters();
    }

    /// <summary>
    /// Rate limiter configuration for the CryptoCom API
    /// </summary>
    public class CryptoComRateLimiters
    {
        /// <summary>
        /// Event for when a rate limit is triggered
        /// </summary>
        public event Action<RateLimitEvent> RateLimitTriggered;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal CryptoComRateLimiters()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Initialize();
        }

        private void Initialize()
        {
            RestPrivate = new RateLimitGate("Rest Private")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerApiKeyPerEndpoint, Array.Empty<IGuardFilter>(), 50, TimeSpan.FromMilliseconds(100), RateLimitWindowType.Sliding));
            RestPrivateSpecific = new RateLimitGate("Rest Private Specific")
                 .AddGuard(new RateLimitGuard(RateLimitGuard.PerApiKeyPerEndpoint, Array.Empty<IGuardFilter>(), 10, TimeSpan.FromMilliseconds(100), RateLimitWindowType.Sliding))
                 .AddGuard(new RateLimitGuard(RateLimitGuard.PerApiKeyPerEndpoint, new ExactPathsFilter(["/exchange/v1/private/get-order-detail"]), 30, TimeSpan.FromMilliseconds(100), RateLimitWindowType.Sliding))
                 .AddGuard(new RateLimitGuard(RateLimitGuard.PerApiKeyPerEndpoint, new ExactPathsFilter(["private/get-trades", "private/get-order-history"]), 1, TimeSpan.FromMilliseconds(1000), RateLimitWindowType.Sliding));

            RestPublic = new RateLimitGate("Rest Public")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerEndpoint, Array.Empty<IGuardFilter>(), 200, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            RestPublicSpecific = new RateLimitGate("Rest Public Specific")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerEndpoint, Array.Empty<IGuardFilter>(), 10, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));

            Socket = new RateLimitGate("Socket")
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, [], 500, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding))
                .AddGuard(new RateLimitGuard(RateLimitGuard.PerHost, [new LimitItemTypeFilter(RateLimitItemType.Request), new ExactPathFilter("/exchange/v1/user")], 150, TimeSpan.FromSeconds(1), RateLimitWindowType.Sliding));
            RestPrivate.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            RestPrivateSpecific.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            RestPublic.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            RestPublicSpecific.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
            Socket.RateLimitTriggered += (x) => RateLimitTriggered?.Invoke(x);
        }


        internal IRateLimitGate RestPrivate { get; private set; }
        internal IRateLimitGate RestPrivateSpecific { get; private set; }
        internal IRateLimitGate RestPublic { get; private set; }
        internal IRateLimitGate RestPublicSpecific { get; private set; }
        internal IRateLimitGate Socket { get; private set; }

    }
}
