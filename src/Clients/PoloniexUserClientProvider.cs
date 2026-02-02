using System.Collections.Concurrent;
using CryptoExchange.Net.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Poloniex.Net.Interfaces.Clients;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net.Clients
{
    /// <inheritdoc />
    public class PoloniexUserClientProvider : IPoloniexUserClientProvider
    {
        private static ConcurrentDictionary<string, IPoloniexRestClient> _restClients = new ConcurrentDictionary<string, IPoloniexRestClient>();
        private static ConcurrentDictionary<string, IPoloniexSocketClient> _socketClients = new ConcurrentDictionary<string, IPoloniexSocketClient>();

        private readonly IOptions<PoloniexRestOptions> _restOptions;
        private readonly IOptions<PoloniexSocketOptions> _socketOptions;
        private readonly HttpClient _httpClient;
        private readonly ILoggerFactory? _loggerFactory;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="optionsDelegate">Options to use for created clients</param>
        public PoloniexUserClientProvider(Action<PoloniexOptions>? optionsDelegate = null)
            : this(null, null, Options.Create(ApplyOptionsDelegate(optionsDelegate).Rest), Options.Create(ApplyOptionsDelegate(optionsDelegate).Socket))
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        public PoloniexUserClientProvider(
            HttpClient? httpClient,
            ILoggerFactory? loggerFactory,
            IOptions<PoloniexRestOptions> restOptions,
            IOptions<PoloniexSocketOptions> socketOptions)
        {
            _httpClient = httpClient ?? new HttpClient();
            _loggerFactory = loggerFactory;
            _restOptions = restOptions;
            _socketOptions = socketOptions;
        }

        /// <inheritdoc />
        public void InitializeUserClient(string userIdentifier, ApiCredentials credentials, PoloniexEnvironment? environment = null)
        {
            CreateRestClient(userIdentifier, credentials, environment);
            CreateSocketClient(userIdentifier, credentials, environment);
        }

        /// <inheritdoc />
        public IPoloniexRestClient GetRestClient(string userIdentifier, ApiCredentials? credentials = null, PoloniexEnvironment? environment = null)
        {
            if (!_restClients.TryGetValue(userIdentifier, out var client))
                client = CreateRestClient(userIdentifier, credentials, environment);

            return client;
        }

        /// <inheritdoc />
        public IPoloniexSocketClient GetSocketClient(string userIdentifier, ApiCredentials? credentials = null, PoloniexEnvironment? environment = null)
        {
            if (!_socketClients.TryGetValue(userIdentifier, out var client))
                client = CreateSocketClient(userIdentifier, credentials, environment);

            return client;
        }

        private IPoloniexRestClient CreateRestClient(string userIdentifier, ApiCredentials? credentials, PoloniexEnvironment? environment)
        {
            var clientRestOptions = SetRestEnvironment(environment);
            var client = new PoloniexRestClient(_httpClient, _loggerFactory, clientRestOptions);
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _restClients.TryAdd(userIdentifier, client);
            }
            return client;
        }

        private IPoloniexSocketClient CreateSocketClient(string userIdentifier, ApiCredentials? credentials, PoloniexEnvironment? environment)
        {
            var clientSocketOptions = SetSocketEnvironment(environment);
            var client = new PoloniexSocketClient(clientSocketOptions!, _loggerFactory);
            if (credentials != null)
            {
                client.SetApiCredentials(credentials);
                _socketClients.TryAdd(userIdentifier, client);
            }
            return client;
        }

        private IOptions<PoloniexRestOptions> SetRestEnvironment(PoloniexEnvironment? environment)
        {
            if (environment == null)
                return _restOptions;

            var newRestClientOptions = new PoloniexRestOptions();
            var restOptions = _restOptions.Value.Set(newRestClientOptions);
            newRestClientOptions.Environment = environment;
            return Options.Create(newRestClientOptions);
        }

        private IOptions<PoloniexSocketOptions> SetSocketEnvironment(PoloniexEnvironment? environment)
        {
            if (environment == null)
                return _socketOptions;

            var newSocketClientOptions = new PoloniexSocketOptions();
            var restOptions = _socketOptions.Value.Set(newSocketClientOptions);
            newSocketClientOptions.Environment = environment;
            return Options.Create(newSocketClientOptions);
        }

        private static T ApplyOptionsDelegate<T>(Action<T>? del) where T : new()
        {
            var opts = new T();
            del?.Invoke(opts);
            return opts;
        }
    }
}
