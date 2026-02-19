using CryptoExchange.Net;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Interfaces.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Poloniex.Net;
using Poloniex.Net.Clients;
using Poloniex.Net.Interfaces.Clients;
using Poloniex.Net.Objects.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions for DI
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services such as the IPoloniexRestClient and IPoloniexSocketClient. Configures the services based on the provided configuration.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configuration">The configuration(section) containing the options</param>
        /// <returns></returns>
        public static IServiceCollection AddPoloniex(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var options = new PoloniexOptions();
            // Reset environment so we know if theyre overriden
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            configuration.Bind(options);

            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            var restEnvName = options.Rest.Environment?.Name ?? options.Environment?.Name ?? PoloniexEnvironment.Live.Name;
            var socketEnvName = options.Socket.Environment?.Name ?? options.Environment?.Name ?? PoloniexEnvironment.Live.Name;
            options.Rest.Environment = PoloniexEnvironment.GetEnvironmentByName(restEnvName) ?? options.Rest.Environment!;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = PoloniexEnvironment.GetEnvironmentByName(socketEnvName) ?? options.Socket.Environment!;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;


            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

            return AddPoloniexCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// Add services such as the IPoloniexRestClient and IPoloniexSocketClient. Services will be configured based on the provided options.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="optionsDelegate">Set options for the Poloniex services</param>
        /// <returns></returns>
        public static IServiceCollection AddPoloniex(
            this IServiceCollection services,
            Action<PoloniexOptions>? optionsDelegate = null)
        {
            var options = new PoloniexOptions();
            // Reset environment so we know if theyre overriden
            options.Rest.Environment = null!;
            options.Socket.Environment = null!;
            optionsDelegate?.Invoke(options);
            if (options.Rest == null || options.Socket == null)
                throw new ArgumentException("Options null");

            options.Rest.Environment = options.Rest.Environment ?? options.Environment ?? PoloniexEnvironment.Live;
            options.Rest.ApiCredentials = options.Rest.ApiCredentials ?? options.ApiCredentials;
            options.Socket.Environment = options.Socket.Environment ?? options.Environment ?? PoloniexEnvironment.Live;
            options.Socket.ApiCredentials = options.Socket.ApiCredentials ?? options.ApiCredentials;

            services.AddSingleton(x => Options.Options.Create(options.Rest));
            services.AddSingleton(x => Options.Options.Create(options.Socket));

            return AddPoloniexCore(services, options.SocketClientLifeTime);
        }

        /// <summary>
        /// DEPRECATED; use <see cref="AddPoloniex(IServiceCollection, Action{PoloniexOptions}?)" /> instead
        /// </summary>
        public static IServiceCollection AddPoloniex(
            this IServiceCollection services,
            Action<PoloniexRestOptions> restDelegate,
            Action<PoloniexSocketOptions>? socketDelegate = null,
            ServiceLifetime? socketClientLifeTime = null)
        {
            services.Configure<PoloniexRestOptions>((x) => { restDelegate?.Invoke(x); });
            services.Configure<PoloniexSocketOptions>((x) => { socketDelegate?.Invoke(x); });

            return AddPoloniexCore(services, socketClientLifeTime);
        }

        private static IServiceCollection AddPoloniexCore(
            this IServiceCollection services,
            ServiceLifetime? socketClientLifeTime = null)
        {
            services.AddHttpClient<IPoloniexRestClient, PoloniexRestClient>((client, serviceProvider) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<PoloniexRestOptions>>().Value;
                client.Timeout = options.RequestTimeout;
                return new PoloniexRestClient(client, serviceProvider.GetRequiredService<ILoggerFactory>(), serviceProvider.GetRequiredService<IOptions<PoloniexRestOptions>>());
            }).ConfigurePrimaryHttpMessageHandler((serviceProvider) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<PoloniexRestOptions>>().Value;
                return LibraryHelpers.CreateHttpClientMessageHandler(options.Proxy, options.HttpKeepAliveInterval);
            });
            services.Add(new ServiceDescriptor(typeof(IPoloniexSocketClient), x => { return new PoloniexSocketClient(x.GetRequiredService<IOptions<PoloniexSocketOptions>>(), x.GetRequiredService<ILoggerFactory>()); }, socketClientLifeTime ?? ServiceLifetime.Singleton));

            services.AddTransient<ICryptoRestClient, CryptoRestClient>();
            services.AddSingleton<ICryptoSocketClient, CryptoSocketClient>();
            services.AddSingleton<IPoloniexUserClientProvider, PoloniexUserClientProvider>(x =>
            new PoloniexUserClientProvider(
                x.GetRequiredService<IHttpClientFactory>().CreateClient(typeof(IPoloniexRestClient).Name),
                x.GetRequiredService<ILoggerFactory>(),
                x.GetRequiredService<IOptions<PoloniexRestOptions>>(),
                x.GetRequiredService<IOptions<PoloniexSocketOptions>>()));
            return services;
        }
    }
}
