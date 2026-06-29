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
    internal partial class PoloniexRestClientExchangeApi : RestApiClient<PoloniexEnvironment, PoloniexAuthenticationProvider, HMACCredential>, IPoloniexRestClientExchangeApi
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
        internal PoloniexRestClientExchangeApi(ILoggerFactory? loggerFactory, HttpClient? httpClient, PoloniexRestOptions options)
            : base(loggerFactory, PoloniexExchange.ExchangeName, httpClient, options.Environment.RestClientAddress, options, options.ExchangeOptions)
        {
            Account = new PoloniexRestClientExchangeApiAccount(this);
            ExchangeData = new PoloniexRestClientExchangeApiExchangeData(_logger, this);
            Trading = new PoloniexRestClientExchangeApiTrading(_logger, this);
        }
        #endregion

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(PoloniexExchange.SerializerContext));

        /// <inheritdoc />
        protected override PoloniexAuthenticationProvider CreateAuthenticationProvider(HMACCredential credentials)
            => new PoloniexAuthenticationProvider(credentials);

        internal Task<HttpResult<T>> SendAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
            => SendToAddressAsync<T>(BaseAddress, definition, parameters, cancellationToken, weight);

        internal async Task<HttpResult<T>> SendToAddressAsync<T>(string baseAddress, RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            definition.BaseAddress = baseAddress;
            var result = await base.SendAsync<T>(definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<T>(result);

            return result;
        }

        /// <inheritdoc />
        protected override Task<HttpResult<DateTime>> GetServerTimestampAsync()
            => ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, TradingMode tradingMode, DateTime? deliverTime = null)
                => PoloniexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);

    }
}
