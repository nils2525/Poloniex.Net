using CryptoExchange.Net.Converters.SystemTextJson;
using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>
    /// Futures 24-hour ticker update.
    /// </summary>
    public class PoloniexFuturesTicker
    {
        /// <summary>[<c>s</c>] Trading pair.</summary>
        [JsonPropertyName("s")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>[<c>o</c>] Opening price.</summary>
        [JsonPropertyName("o")]
        public decimal OpenPrice { get; set; }

        /// <summary>[<c>l</c>] Lowest price in the past 24 hours.</summary>
        [JsonPropertyName("l")]
        public decimal LowPrice { get; set; }

        /// <summary>[<c>h</c>] Highest price in the past 24 hours.</summary>
        [JsonPropertyName("h")]
        public decimal HighPrice { get; set; }

        /// <summary>[<c>c</c>] Closing price.</summary>
        [JsonPropertyName("c")]
        public decimal ClosePrice { get; set; }

        /// <summary>[<c>qty</c>] Base quantity or number of contracts traded.</summary>
        [JsonPropertyName("qty")]
        public decimal Quantity { get; set; }

        /// <summary>[<c>amt</c>] Quote quantity traded.</summary>
        [JsonPropertyName("amt")]
        public decimal QuoteQuantity { get; set; }

        /// <summary>[<c>tC</c>] Number of trades.</summary>
        [JsonPropertyName("tC")]
        public long TradeCount { get; set; }

        /// <summary>[<c>sT</c>] Start of the 24-hour interval.</summary>
        [JsonPropertyName("sT")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime StartTime { get; set; }

        /// <summary>[<c>cT</c>] End of the 24-hour interval.</summary>
        [JsonPropertyName("cT")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CloseTime { get; set; }

        /// <summary>[<c>dC</c>] Daily price change in decimal form.</summary>
        [JsonPropertyName("dC")]
        public decimal DailyPriceChange { get; set; }

        /// <summary>[<c>bPx</c>] Best bid price.</summary>
        [JsonPropertyName("bPx")]
        public decimal BestBidPrice { get; set; }

        /// <summary>[<c>bSz</c>] Quantity at the best bid.</summary>
        [JsonPropertyName("bSz")]
        public decimal BestBidQuantity { get; set; }

        /// <summary>[<c>aPx</c>] Best ask price.</summary>
        [JsonPropertyName("aPx")]
        public decimal BestAskPrice { get; set; }

        /// <summary>[<c>aSz</c>] Quantity at the best ask.</summary>
        [JsonPropertyName("aSz")]
        public decimal BestAskQuantity { get; set; }

        /// <summary>[<c>ts</c>] Push timestamp.</summary>
        [JsonPropertyName("ts")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Timestamp { get; set; }
    }
}
