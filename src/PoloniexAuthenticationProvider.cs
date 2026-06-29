using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Objects;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net
{
    internal class PoloniexAuthenticationProvider : AuthenticationProvider<HMACCredential>
    {
        public override string Key => ApiCredentials.Key;

        public PoloniexAuthenticationProvider(HMACCredential credentials) : base(credentials)
        { }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.RequestDefinition.Authenticated)
                return;

            // https://api-docs.poloniex.com/spot/api/#authentication
            var nonce = Guid.NewGuid().ToString();
            var timestamp = GetMillisecondTimestamp(apiClient);
            var options = (PoloniexRestOptions)apiClient.ClientOptions;

            requestConfig.Headers ??= new Dictionary<string, string>();
            requestConfig.Headers["key"] = ApiCredentials.Key;
            requestConfig.Headers["signTimestamp"] = timestamp;
            requestConfig.Headers["recvWindow"] = options.ReceiveWindow.TotalMilliseconds.ToString();

            requestConfig.QueryParameters ??= new Parameters(PoloniexExchange._parameterSerializationSettings);
            var contentParameters = requestConfig.QueryParameters;
            contentParameters.Add("signTimestamp", timestamp);

            // Sort parameters
            var sortedParameters = new Parameters(new ParameterSerializationSettings
            {
                Decimal = DecimalSerialization.String,
                Array = ArrayParametersSerialization.MultipleValues,
                Sort = true
            });
            foreach (var parameter in contentParameters.OrderBy(c => c.Key))
                sortedParameters.Add(parameter.Key, parameter.Value);
            contentParameters = sortedParameters;
            requestConfig.QueryParameters = sortedParameters;

            var signatureText =
                requestConfig.RequestDefinition.Method + "\n" +
                requestConfig.RequestDefinition.Path + "\n" +
                contentParameters.CreateParamString(requestConfig.BodyParameters?.Any() != true, ArrayParametersSerialization.MultipleValues);

            requestConfig.Headers["signature"] = SignHMACSHA256(ApiCredentials, signatureText, SignOutputType.Base64);
        }

        public Parameters AuthenticateSocket()
        {
            var key = ApiCredentials.Key;
            var timestamp = DateTimeConverter.ConvertToMilliseconds(DateTime.UtcNow);
            var signatureText =
                "GET" + "\n" +
                "/ws" + "\n" +
                "signTimestamp=" + timestamp;

            return new Parameters(PoloniexExchange._parameterSerializationSettings)
            {
                { "key", key},
                { "signTimestamp", timestamp},
                { "signature", SignHMACSHA256(ApiCredentials, signatureText, SignOutputType.Base64)}
            };
        }
    }
}
