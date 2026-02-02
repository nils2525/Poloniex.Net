using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Objects.Errors;

namespace Poloniex.Net.Clients.MessageHandlers
{
    internal class PoloniexRestMessageHandler : JsonRestMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(PoloniexExchange.SerializerContext);

        public override async ValueTask<Error> ParseErrorResponse(int httpStatusCode, HttpResponseHeaders responseHeaders, Stream responseStream)
        {
            var (parseError, document) = await GetJsonDocument(responseStream).ConfigureAwait(false);
            if (parseError != null)
                return parseError;

            var code = document!.RootElement.TryGetProperty("code", out var codeProp) ? codeProp.GetRawText() : null;
            var msg = document.RootElement.TryGetProperty("message", out var msgProp) ? msgProp.GetString() : null;

            return new ServerError(code ?? String.Empty, new(ErrorType.Unknown, msg ?? String.Empty));

        }
    }
}
