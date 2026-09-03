using System.Text.Json.Serialization;

namespace Poloniex.Net.Objects.Models
{
    /// <summary>
    /// Futures product information.
    /// </summary>
    public class PoloniexFuturesInstrument
    {
        /// <summary>[<c>symbol</c>] Trading pair.</summary>
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;

        /// <summary>[<c>bAsset</c>] Underlying index asset.</summary>
        [JsonPropertyName("bAsset")]
        public string BaseAssetId { get; set; } = string.Empty;

        /// <summary>[<c>bCcy</c>] Base currency.</summary>
        [JsonPropertyName("bCcy")]
        public string BaseAsset { get; set; } = string.Empty;

        /// <summary>[<c>qCcy</c>] Quote currency.</summary>
        [JsonPropertyName("qCcy")]
        public string QuoteAsset { get; set; } = string.Empty;

        /// <summary>[<c>visibleStartTime</c>] Time the symbol became visible.</summary>
        [JsonPropertyName("visibleStartTime")]
        public long VisibleStartTime { get; set; }

        /// <summary>[<c>tradableStartTime</c>] Time the symbol became tradable.</summary>
        [JsonPropertyName("tradableStartTime")]
        public long TradableStartTime { get; set; }

        /// <summary>[<c>sCcy</c>] Settlement currency.</summary>
        [JsonPropertyName("sCcy")]
        public string SettleAsset { get; set; } = string.Empty;

        /// <summary>[<c>tSz</c>] Tick size.</summary>
        [JsonPropertyName("tSz")]
        public decimal TickSize { get; set; }

        /// <summary>[<c>pxScale</c>] Supported price scales.</summary>
        [JsonPropertyName("pxScale")]
        public string PriceScale { get; set; } = string.Empty;

        /// <summary>[<c>lotSz</c>] Contract quantity precision.</summary>
        [JsonPropertyName("lotSz")]
        public decimal LotSize { get; set; }

        /// <summary>[<c>minSz</c>] Minimum quantity in contracts.</summary>
        [JsonPropertyName("minSz")]
        public decimal MinSize { get; set; }

        /// <summary>[<c>ctVal</c>] Contract face value.</summary>
        [JsonPropertyName("ctVal")]
        public decimal ContractValue { get; set; }

        /// <summary>[<c>status</c>] Trading status.</summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>[<c>oDate</c>] Listing date.</summary>
        [JsonPropertyName("oDate")]
        public long ListingDate { get; set; }

        /// <summary>[<c>maxPx</c>] Maximum order price.</summary>
        [JsonPropertyName("maxPx")]
        public decimal MaxPrice { get; set; }

        /// <summary>[<c>minPx</c>] Minimum order price.</summary>
        [JsonPropertyName("minPx")]
        public decimal MinPrice { get; set; }

        /// <summary>[<c>maxQty</c>] Deprecated maximum order quantity.</summary>
        [JsonPropertyName("maxQty")]
        public decimal MaxQuantity { get; set; }

        /// <summary>[<c>minQty</c>] Minimum order quantity.</summary>
        [JsonPropertyName("minQty")]
        public decimal MinQuantity { get; set; }

        /// <summary>[<c>marketMaxQty</c>] Maximum market-order quantity.</summary>
        [JsonPropertyName("marketMaxQty")]
        public decimal MarketMaxQuantity { get; set; }

        /// <summary>[<c>limitMaxQty</c>] Maximum limit-order quantity.</summary>
        [JsonPropertyName("limitMaxQty")]
        public decimal LimitMaxQuantity { get; set; }

        /// <summary>[<c>maxLever</c>] Maximum leverage.</summary>
        [JsonPropertyName("maxLever")]
        public decimal MaxLeverage { get; set; }

        /// <summary>[<c>lever</c>] Default leverage.</summary>
        [JsonPropertyName("lever")]
        public decimal Leverage { get; set; }

        /// <summary>[<c>ordPxRange</c>] Permitted order-price range.</summary>
        [JsonPropertyName("ordPxRange")]
        public decimal OrderPriceRange { get; set; }

        /// <summary>[<c>ctType</c>] Contract type.</summary>
        [JsonPropertyName("ctType")]
        public string ContractType { get; set; } = string.Empty;

        /// <summary>[<c>alias</c>] Delivery alias, empty for perpetuals.</summary>
        [JsonPropertyName("alias")]
        public string Alias { get; set; } = string.Empty;

        /// <summary>[<c>iM</c>] Initial margin rate.</summary>
        [JsonPropertyName("iM")]
        public decimal InitialMarginRate { get; set; }

        /// <summary>[<c>mM</c>] Maintenance margin rate.</summary>
        [JsonPropertyName("mM")]
        public decimal MaintenanceMarginRate { get; set; }

        /// <summary>[<c>mR</c>] Maximum risk limit.</summary>
        [JsonPropertyName("mR")]
        public decimal MaximumRiskLimit { get; set; }
    }
}
