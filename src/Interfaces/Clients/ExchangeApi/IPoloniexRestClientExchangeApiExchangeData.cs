using CryptoExchange.Net.Objects;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange exchange data endpoints. Exchange data includes market data (tickers, order books, etc) and system status.
    /// </summary>
    public interface IPoloniexRestClientExchangeApiExchangeData
    {
        /// <summary>
        /// Gets the server time
        /// <para><a href="https://api-docs.poloniex.com/spot/api/public/reference-data#system-timestamp" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns></returns>
        Task<HttpResult<DateTime>> GetServerTimeAsync(CancellationToken ct = default);

        /// <summary>
        /// Get symbols/instruments
        /// <para><a href="https://api-docs.poloniex.com/spot/api/public/reference-data#symbol-information" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<PoloniexSymbol[]>> GetSymbolsAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://api-docs.poloniex.com/spot/api/public/reference-data#currencyv2-information" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<PoloniexCurrency[]>> GetCurrencyInformationAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://api-docs.poloniex.com/spot/api/public/market-data#ticker" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<PoloniexTicker[]>> GetTickersAsync(CancellationToken ct = default);

        /// <summary>
        /// 
        /// <para><a href="https://api-docs.poloniex.com/spot/api/public/market-data#ticker" /></para>
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        Task<HttpResult<PoloniexTicker>> GetTickerAsync(string symbol, CancellationToken ct = default);
    }
}
