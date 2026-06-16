using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>
    /// Futures product information.
    /// </summary>
    public class PoloniexFuturesInstrument
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        [JsonPropertyName("bAsset")]
        public string BaseAssetId { get; set; } = string.Empty;

        [JsonPropertyName("bCcy")]
        public string BaseAsset { get; set; } = string.Empty;

        [JsonPropertyName("qCcy")]
        public string QuoteAsset { get; set; } = string.Empty;

        [JsonPropertyName("sCcy")]
        public string SettleAsset { get; set; } = string.Empty;

        [JsonPropertyName("tSz")]
        public decimal TickSize { get; set; }

        [JsonPropertyName("lotSz")]
        public decimal LotSize { get; set; }

        [JsonPropertyName("minSz")]
        public decimal MinSize { get; set; }

        [JsonPropertyName("ctVal")]
        public decimal ContractValue { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("maxQty")]
        public decimal MaxQuantity { get; set; }

        [JsonPropertyName("minQty")]
        public decimal MinQuantity { get; set; }

        [JsonPropertyName("marketMaxQty")]
        public decimal MarketMaxQuantity { get; set; }

        [JsonPropertyName("limitMaxQty")]
        public decimal LimitMaxQuantity { get; set; }

        [JsonPropertyName("ctType")]
        public string ContractType { get; set; } = string.Empty;

        [JsonPropertyName("alias")]
        public string Alias { get; set; } = string.Empty;
    }
}
