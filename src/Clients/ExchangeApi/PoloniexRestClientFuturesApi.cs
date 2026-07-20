using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Clients.MessageHandlers;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc cref="IPoloniexRestClientFuturesApi" />
    internal class PoloniexRestClientFuturesApi : RestApiClient<PoloniexEnvironment, PoloniexAuthenticationProvider, HMACCredential>, IPoloniexRestClientFuturesApi
    {
        protected override IRestMessageHandler MessageHandler { get; } = new PoloniexRestMessageHandler();

        /// <inheritdoc />
        public IPoloniexRestClientFuturesApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Initializes the Poloniex futures REST API client.
        /// </summary>
        /// <param name="baseClient">The owning Poloniex REST client.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="options">The REST client options.</param>
        internal PoloniexRestClientFuturesApi(PoloniexRestClient baseClient, ILoggerFactory? loggerFactory, HttpClient? httpClient, PoloniexRestOptions options)
            : base(loggerFactory, PoloniexExchange.ExchangeName, httpClient, options.Environment.RestClientAddress, options, options.ExchangeOptions)
        {
            ExchangeData = new PoloniexRestClientFuturesApiExchangeData(_logger, this);
            StandardRequestHeaders = PoloniexExchange.CreateRestRequestHeaders(baseClient.CryptoExchangeLibVersion);
        }

        /// <inheritdoc />
        protected override IMessageSerializer CreateSerializer()
            => new SystemTextJsonMessageSerializer(SerializerOptions.WithConverters(PoloniexExchange.SerializerContext));

        /// <inheritdoc />
        protected override PoloniexAuthenticationProvider CreateAuthenticationProvider(HMACCredential credentials)
            => new PoloniexAuthenticationProvider(credentials);

        internal async Task<HttpResult<T>> SendAsync<T>(RequestDefinition definition, Parameters? parameters, CancellationToken cancellationToken, int? weight = null) where T : class
        {
            definition.BaseAddress = BaseAddress;
            var result = await base.SendAsync<T>(definition, parameters, cancellationToken, null, weight).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<T>(result);

            return result;
        }

        /// <inheritdoc />
        protected override Task<HttpResult<DateTime>> GetServerTimestampAsync()
            => Task.FromResult(new HttpResult<DateTime>(PoloniexExchange.ExchangeName, DateTime.UtcNow, null));

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, CryptoExchange.Net.SharedApis.TradingMode tradingMode, DateTime? deliverTime = null)
            => PoloniexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
