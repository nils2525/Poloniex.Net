using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>Poloniex futures account and position-configuration endpoints.</summary>
    public interface IPoloniexRestClientFuturesApiAccount
    {
        /// <summary>Get futures account balances.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/account/balance" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesAccountBalance>> GetBalancesAsync(CancellationToken ct = default);

        /// <summary>Get the account-wide position mode.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/positions/position-mode-get" /></para>
        /// </summary>
        Task<HttpResult<PoloniexFuturesPositionModeInfo>> GetPositionModeAsync(CancellationToken ct = default);

        /// <summary>Set the account-wide position mode.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/positions/position-mode-switch" /></para>
        /// </summary>
        /// <param name="positionMode">Position mode.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<HttpResult<object>> SetPositionModeAsync(PoloniexFuturesPositionMode positionMode, CancellationToken ct = default);

        /// <summary>Get leverage configurations for a symbol.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/positions/get-leverages" /></para>
        /// </summary>
        /// <param name="symbol">Symbol.</param>
        /// <param name="marginMode">Optional margin-mode filter.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<HttpResult<PoloniexFuturesLeverage[]>> GetLeveragesAsync(string symbol, PoloniexFuturesMarginMode? marginMode = null, CancellationToken ct = default);

        /// <summary>Set leverage for a symbol, margin mode, and position side.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/v3/futures/api/positions/set-leverage" /></para>
        /// </summary>
        /// <param name="symbol">Symbol.</param>
        /// <param name="marginMode">Margin mode.</param>
        /// <param name="positionSide">Position side.</param>
        /// <param name="leverage">Leverage.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<HttpResult<PoloniexFuturesLeverage>> SetLeverageAsync(string symbol, PoloniexFuturesMarginMode marginMode,
            PoloniexFuturesPositionSide positionSide, decimal leverage, CancellationToken ct = default);
    }
}
