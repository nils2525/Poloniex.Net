using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CryptoExchange.Net.Converters.MessageParsing.DynamicConverters;
using CryptoExchange.Net.Converters.SystemTextJson;
using CryptoExchange.Net.Converters.SystemTextJson.MessageHandlers;
using Poloniex.Net.Objects.Internal;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Clients.MessageHandlers
{
    internal class PoloniexSocketMessageHandler : JsonSocketMessageHandler
    {
        public override JsonSerializerOptions Options { get; } = SerializerOptions.WithConverters(PoloniexExchange.SerializerContext);

        public PoloniexSocketMessageHandler()
        {
            AddTopicMapping<PoloniexSocketSubscriptionResponse>(r => String.Join(",", r.Symbols.Order()));
            AddTopicMapping<PoloniexSubscriptionEvent<PoloniexTrade>>(c => c.Data.First().Symbol);
            AddTopicMapping<PoloniexSubscriptionEvent<PoloniexCandle>>(c => c.Data.First().Symbol);
            AddTopicMapping<PoloniexSubscriptionEvent<PoloniexOrderBook>>(c => c.Data.First().Symbol);
        }

        protected override MessageTypeDefinition[] TypeEvaluators { get; } = [
            new MessageTypeDefinition(){
                Fields = [
                    new PropertyFieldReference("event"),
                    new PropertyFieldReference("channel")],
                TypeIdentifierCallback = x => $"{x.FieldValue("event")}#{x.FieldValue("channel")}"
            },
            new MessageTypeDefinition(){
                Fields = [
                    new PropertyFieldReference("channel"),
                    new PropertyFieldReference("data")],
                TypeIdentifierCallback = x => x.FieldValue("channel")!
            },
            new MessageTypeDefinition(){
                Fields = [new PropertyFieldReference("event").WithEqualConstraint("error")],
                StaticIdentifier = "error"
            },
            new MessageTypeDefinition(){
                Fields = [new PropertyFieldReference("event").WithEqualConstraint("pong")],
                StaticIdentifier = "pong"
            },
        ];
    }
}
