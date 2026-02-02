using System.Text.Json.Serialization;
using CryptoExchange.Net.Converters.SystemTextJson;
using Poloniex.Net.Enums;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexSymbol
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("baseCurrencyName")]
        public string BaseAssetName { get; set; } = string.Empty;

        [JsonPropertyName("quoteCurrencyName")]
        public string QuoteAssetName { get; set; } = string.Empty;

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("state")]
        public PoloniexSymbolState State { get; set; }

        [JsonPropertyName("visibleStartTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime VisibleStartTime { get; set; }

        [JsonPropertyName("tradableStartTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime TradableStartTime { get; set; }

        [JsonPropertyName("symbolTradeLimit")]
        public PoloniexSymbolTradeLimit TradeLimit { get; set; } = new PoloniexSymbolTradeLimit();

        [JsonPropertyName("crossMargin")]
        public PoloniexSymbolCrossMargin CrossMargin { get; set; } = new PoloniexSymbolCrossMargin();
    }

    public class PoloniexSymbolTradeLimit
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("priceScale")]
        public int PriceScale { get; set; }

        [JsonPropertyName("quantityScale")]
        public int QuantityScale { get; set; }

        [JsonPropertyName("amountScale")]
        public int AmountScale { get; set; }

        [JsonPropertyName("minQuantity")]
        public decimal MinQuantity { get; set; }

        [JsonPropertyName("maxQuantity")]
        public decimal MaxQuantity { get; set; }

        [JsonPropertyName("minAmount")]
        public decimal MinNotional { get; set; }

        [JsonPropertyName("maxAmount")]
        public decimal MaxNotional { get; set; }

        [JsonPropertyName("highestBid")]
        public decimal MaxPrice { get; set; }

        [JsonPropertyName("lowestAsk")]
        public decimal MinPrice { get; set; }
    }

    public class PoloniexSymbolCrossMargin
    {
        [JsonPropertyName("supportCrossMargin")]
        public bool SupportCrossMargin { get; set; }

        [JsonPropertyName("maxLeverage")]
        public int MaxLeverage { get; set; }
    }
}

