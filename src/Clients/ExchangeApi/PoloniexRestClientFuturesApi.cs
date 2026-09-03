using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;
using Microsoft.Extensions.Logging;
using Poloniex.Net.Clients.MessageHandlers;
using Poloniex.Net.Interfaces.Clients.ExchangeApi;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net.Clients.ExchangeApi
{
    /// <inheritdoc cref="IPoloniexRestClientFuturesApi" />
    internal class PoloniexRestClientFuturesApi : RestApiClient<PoloniexEnvironment, PoloniexAuthenticationProvider, HMACCredential>, IPoloniexRestClientFuturesApi
    {
        private readonly PoloniexRestClient _baseClient;

        protected override IRestMessageHandler MessageHandler { get; } = new PoloniexRestMessageHandler();

        /// <inheritdoc />
        public IPoloniexRestClientFuturesApiExchangeData ExchangeData { get; }
        /// <inheritdoc />
        public IPoloniexRestClientFuturesApiAccount Account { get; }
        /// <inheritdoc />
        public IPoloniexRestClientFuturesApiTrading Trading { get; }

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
            _baseClient = baseClient;
            ExchangeData = new PoloniexRestClientFuturesApiExchangeData(_logger, this);
            Account = new PoloniexRestClientFuturesApiAccount(this);
            Trading = new PoloniexRestClientFuturesApiTrading(this);
            StandardRequestHeaders = PoloniexExchange.CreateRequestHeaders(baseClient.CryptoExchangeLibVersion);
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

        /// <summary>Sends a V3 futures request and unwraps the standard response envelope.</summary>
        internal async Task<HttpResult<T>> SendFuturesAsync<T>(RequestDefinition definition,
            Parameters? parameters, CancellationToken cancellationToken, int? weight = null)
            where T : class
        {
            var result = await SendAsync<Objects.Models.PoloniexFuturesRestResult<T>>(
                definition, parameters, cancellationToken, weight).ConfigureAwait(false);
            if (!result.Success)
                return HttpResult.Fail<T>(result);
            if (result.Data == null)
                return result.AsError<T>(new ServerError(-1,
                    new(ErrorType.Unknown, "Poloniex Futures response data is null")));
            if (result.Data.Code != 200)
                return result.AsError<T>(new ServerError(result.Data.Code,
                    new(ErrorType.Unknown, result.Data.Message)));
            return result.As(result.Data.Data);
        }

        /// <inheritdoc />
        protected override Task<HttpResult<DateTime>> GetServerTimestampAsync()
            => _baseClient.ExchangeApi.ExchangeData.GetServerTimeAsync();

        /// <inheritdoc />
        public override string FormatSymbol(string baseAsset, string quoteAsset, CryptoExchange.Net.SharedApis.TradingMode tradingMode, DateTime? deliverTime = null)
            => PoloniexExchange.FormatSymbol(baseAsset, quoteAsset, tradingMode, deliverTime);
    }
}
