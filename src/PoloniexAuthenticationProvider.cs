using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net
{
    internal class PoloniexAuthenticationProvider : AuthenticationProvider
    {
        public override ApiCredentialsType[] SupportedCredentialTypes { get; } = [ApiCredentialsType.Hmac];

        public PoloniexAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        { }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.Authenticated)
                return;

            // https://api-docs.poloniex.com/spot/api/#authentication
            var nonce = Guid.NewGuid().ToString();
            var timestamp = GetMillisecondTimestamp(apiClient);
            var options = (PoloniexRestOptions)apiClient.ClientOptions;

            requestConfig.Headers ??= new Dictionary<string, string>();
            requestConfig.Headers["key"] = _credentials.Key;
            requestConfig.Headers["signTimestamp"] = timestamp;
            requestConfig.Headers["recvWindow"] = options.ReceiveWindow.TotalMilliseconds.ToString();

            requestConfig.QueryParameters ??= new Dictionary<string, object>();
            var contentParameters = requestConfig.QueryParameters;
            contentParameters.Add("signTimestamp", timestamp);

            // Sort parameters
            contentParameters = contentParameters.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            var signatureText =
                requestConfig.Method + "\n" +
                requestConfig.Path + "\n" +
                contentParameters.CreateParamString(requestConfig.BodyParameters?.Any() != true, ArrayParametersSerialization.MultipleValues);

            requestConfig.Headers["signature"] = SignHMACSHA256(signatureText, SignOutputType.Base64);
        }

        public ParameterCollection AuthenticateSocket()
        {
            var key = _credentials.Key;
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow);
            var signatureText =
                "GET" + "\n" +
                "/ws" + "\n" +
                "signTimestamp=" + timestamp;

            return new ParameterCollection()
            {
                { "key", key},
                { "signTimestamp", timestamp},
                { "signature", SignHMACSHA256(signatureText, SignOutputType.Base64)}
            };
        }
    }
}
