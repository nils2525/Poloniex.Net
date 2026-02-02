using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Objects.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Poloniex.Net.Clients.ExchangeApi;
using Poloniex.Net.Interfaces.Clients;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net.Clients
{
    /// <inheritdoc cref="IPoloniexSocketClient" />
    public class PoloniexSocketClient : BaseSocketClient, IPoloniexSocketClient
    {
        #region fields
        #endregion

        #region Api clients


        /// <inheritdoc />
        public IPoloniexSocketClientExchangeApi ExchangeApi { get; }


        #endregion

        #region constructor/destructor

        /// <summary>
        /// Create a new instance of CryptoComSocketClient
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public PoloniexSocketClient(Action<PoloniexSocketOptions>? optionsDelegate = null)
            : this(Options.Create(ApplyOptionsDelegate(optionsDelegate)), null)
        {
        }

        /// <summary>
        /// Create a new instance of CryptoComSocketClient
        /// </summary>
        /// <param name="loggerFactory">The logger factory</param>
        /// <param name="options">Option configuration</param>
        public PoloniexSocketClient(IOptions<PoloniexSocketOptions> options, ILoggerFactory? loggerFactory = null) : base(loggerFactory, "Poloniex")
        {
            Initialize(options.Value);

            ExchangeApi = AddApiClient(new PoloniexSocketClientExchangeApi(_logger, options.Value));
        }
        #endregion

        /// <inheritdoc />
        public void SetOptions(UpdateOptions options)
        {
            ExchangeApi.SetOptions(options);
        }

        /// <summary>
        /// Set the default options to be used when creating new clients
        /// </summary>
        /// <param name="optionsDelegate">Option configuration delegate</param>
        public static void SetDefaultOptions(Action<PoloniexSocketOptions> optionsDelegate)
        {
            PoloniexSocketOptions.Default = ApplyOptionsDelegate(optionsDelegate);
        }

        /// <inheritdoc />
        public void SetApiCredentials(ApiCredentials credentials)
        {

            ExchangeApi.SetApiCredentials(credentials);

        }
    }
}
