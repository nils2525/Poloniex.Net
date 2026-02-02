using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.SharedApis;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Clients.MessageHandlers;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc cref="IPoloniexRestClientExchangeApi" />
    internal partial class PoloniexRestClientExchangeApi : RestApiClient, IPoloniexRestClientExchangeApi
    {
        protected override IRestMessageHandler MessageHandler { get; } = new PoloniexRestMessageHandler();

        #region Api clients
        /// <inheritdoc />
        public IPoloniexClientExchangeApiAccount Account { get; }
        /// <inheritdoc />
        public IPoloniexRestClientExchangeApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IPoloniexRestClientExchangeApiTrading Trading { get; }
        /// <inheritdoc />
        public string ExchangeName => "Poloniex";
        #endregion

        #region constructor/destructor
        internal PoloniexRestClientExchangeApi(ILogger logger, HttpClient? httpClient, PoloniexRestOptions options)
            : base(logger, httpClient, options.Environment.RestClientAddress, options, options.ExchangeOptions)
        {
            Account = new PoloniexRestClientExchangeApiAccount(this);
            ExchangeData = new PoloniexRestClientExchangeApiExchangeData(logger, this);
            Trading = new PoloniexRestClientExchangeApiTrading(logger, this);
        }
        #endregion

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(PoloniexExchange.SerializerContext));

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new PoloniexAuthenticationProvider(credentials);

        internal Task<WebCallResult<T>> SendAsync<T>(RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight);

        internal async Task<WebCallResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, ParameterCollection? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            var result = await base.SendAsync<T>(baseAddress, definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result)
                return result.As<T>(default);

            return result;
        }

        /// <inheritdoc />
        protected override Task<WebCallResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => PoloniexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

    }
}
