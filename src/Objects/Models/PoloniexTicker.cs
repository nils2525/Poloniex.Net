using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    public class PoloniexTicker
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("open")]
        public decimal Open { get; set; }

        [JsonPropertyName("low")]
        public decimal Low { get; set; }

        [JsonPropertyName("high")]
        public decimal High { get; set; }

        [JsonPropertyName("close")]
        public decimal LastPrice { get; set; }

        [JsonPropertyName("quantity")]
        public decimal Volume { get; set; }

        [JsonPropertyName("amount")]
        public decimal QuoteVolume { get; set; }

        [JsonPropertyName("tradeCount")]
        public long TradeCount { get; set; }

        [JsonPropertyName("startTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("closeTime")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CloseTime { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; } = string.Empty;

        [JsonPropertyName("dailyChange")]
        public decimal DailyChange { get; set; }

        [JsonPropertyName("bid")]
        public decimal Bid { get; set; }

        [JsonPropertyName("bidQuantity")]
        public decimal BidQuantity { get; set; }

        [JsonPropertyName("ask")]
        public decimal Ask { get; set; }

        [JsonPropertyName("askQuantity")]
        public decimal AskQuantity { get; set; }

        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("markPrice")]
        public decimal? MarkPrice { get; set; }
    }
}
