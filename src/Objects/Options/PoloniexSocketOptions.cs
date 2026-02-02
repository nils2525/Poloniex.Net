using CryptoExchange.Net.Objects.Options;

namespace Poloniex.Net.Objects.Options
{
    /// <summary>
    /// Options for the CryptoComSocketClient
    /// </summary>
    public class PoloniexSocketOptions : SocketExchangeOptions<PoloniexEnvironment>
    {
        /// <summary>
        /// Default options for new clients
        /// </summary>
        internal static PoloniexSocketOptions Default { get; set; } = new PoloniexSocketOptions()
        {
            Environment = PoloniexEnvironment.Live,
            SocketSubscriptionsCombineTarget = 10,
            MaxSocketConnections = 2000,
            SocketNoDataTimeout = TimeSpan.FromSeconds(40) // Ping is send every 30 seconds
        };

        /// <summary>
        /// ctor
        /// </summary>
        public PoloniexSocketOptions()
        {
            Default?.Set(this);
        }

        /// <summary>
        /// Exchange API options
        /// </summary>
        public SocketApiOptions ExchangeOptions { get; private set; } = new SocketApiOptions();

        internal PoloniexSocketOptions Set(PoloniexSocketOptions targetOptions)
        {
            targetOptions = base.Set<PoloniexSocketOptions>(targetOptions);
            targetOptions.ExchangeOptions = ExchangeOptions.Set(targetOptions.ExchangeOptions);
            return targetOptions;
        }
    }
}
