using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Clients;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Poloniex.Net.Objects.Options;

namespace Poloniex.Net
{
    internal class PoloniexAuthenticationProvider : AuthenticationProvider<HMACCredential>
    {
        private static readonly IMessageSerializer _serializer =
            new SystemTextJsonMessageSerializer(
                SerializerOptions.WithConverters(PoloniexExchange.SerializerContext));

        public override string Key => ApiCredentials.Key;

        public PoloniexAuthenticationProvider(HMACCredential credentials) : base(credentials)
        { }

        public override void ProcessRequest(RestApiClient apiClient, RestRequestConfiguration requestConfig)
        {
            if (!requestConfig.RequestDefinition.Authenticated)
                return;

            // Spot and V3 Futures use the same HMAC-SHA256 signing scheme.
            var timestamp = GetMillisecondTimestamp(apiClient);
            var options = (PoloniexRestOptions)apiClient.ClientOptions;

            requestConfig.Headers ??= new Dictionary<string, string>();
            requestConfig.Headers["key"] = ApiCredentials.Key;
            requestConfig.Headers["signatureMethod"] = "HmacSHA256";
            requestConfig.Headers["signatureVersion"] = "2";
            requestConfig.Headers["signTimestamp"] = timestamp;
            requestConfig.Headers["recvWindow"] = options.ReceiveWindow.TotalMilliseconds.ToString();

            Parameters contentParameters;
            var hasBody = requestConfig.BodyParameters?.Any() == true;
            if (hasBody)
            {
                var body = GetSerializedBody(_serializer, requestConfig.BodyParameters);
                requestConfig.SetBodyContent(body);
                contentParameters = new Parameters(PoloniexExchange._parameterSerializationSettings)
                {
                    { "requestBody", body },
                    { "signTimestamp", timestamp }
                };
            }
            else
            {
                requestConfig.QueryParameters ??= new Parameters(PoloniexExchange._parameterSerializationSettings);
                requestConfig.QueryParameters.Add("signTimestamp", timestamp);
                contentParameters = requestConfig.QueryParameters;
            }

            // Sort parameters
            var sortedParameters = new Parameters(new ParameterSerializationSettings
            {
                Decimal = DecimalSerialization.String,
                Array = ArrayParametersSerialization.MultipleValues,
                Sort = true,
                SortComparer = StringComparer.Ordinal
            });
            foreach (var parameter in contentParameters.OrderBy(c => c.Key, StringComparer.Ordinal))
                sortedParameters.Add(parameter.Key, parameter.Value);
            contentParameters = sortedParameters;
            if (!hasBody)
                requestConfig.QueryParameters = sortedParameters;

            var signatureText =
                requestConfig.RequestDefinition.Method + "\n" +
                requestConfig.RequestDefinition.Path + "\n" +
                contentParameters.CreateParamString(!hasBody, ArrayParametersSerialization.MultipleValues);

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
                { "signatureMethod", "HmacSHA256"},
                { "signatureVersion", "2"},
                { "signature", SignHMACSHA256(ApiCredentials, signatureText, SignOutputType.Base64)}
            };
        }
    }
}
