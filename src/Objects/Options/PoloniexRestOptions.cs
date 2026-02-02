using CryptoExchange.Net.Objects.Options;

namespace Poloniex.Net.Objects.Options
{
    /// <summary>
    /// Options for the CryptoComRestClient
    /// </summary>
    public class PoloniexRestOptions : RestExchangeOptions<PoloniexEnvironment>
    {
        public TimeSpan ReceiveWindow { get; set; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static PoloniexRestOptions Default { get; set; } = new PoloniexRestOptions()
        {
            Environment = PoloniexEnvironment.Live,
            AutoTimestamp = true
        };

        /// <summary>
        /// ctor
        /// </summary>
        public PoloniexRestOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Exchange API options
        /// </summary>
        public RestApiOptions ExchangeOptions { get; private set; } = new RestApiOptions();

        internal PoloniexRestOptions Set(PoloniexRestOptions targetOptions)
        {
            targetOptions = base.Set<PoloniexRestOptions>(targetOptions);
            targetOptions.ExchangeOptions = ExchangeOptions.Set(targetOptions.ExchangeOptions);
            targetOptions.ReceiveWindow = ReceiveWindow;
            return targetOptions;
        }
    }
}
