using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;
using Poloniex.Net.Objects.Models;

namespace Poloniex.Net.Interfaces.Clients.ExchangeApi
{
    /// <summary>
    /// CryptoCom Exchange account endpoints. Account endpoints include balance info, withdraw/deposit info and requesting and account settings
    /// </summary>
    public interface IPoloniexClientExchangeApiAccount
    {
        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/account#account-information" />
        /// </summary>
        Task<HttpResult<PoloniexAccount[]>> GetAccountDetailsAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/account#all-account-balances" />
        /// </summary>
        Task<HttpResult<PoloniexAccountBalance[]>> GetAccountBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// Transfer funds between the Spot and Futures accounts.
        /// <para>Docs: <a href="https://api-docs.poloniex.com/spot/api/private/account#accounts-transfer" /></para>
        /// </summary>
        /// <param name="currency">Currency.</param>
        /// <param name="amount">Amount, with at most eight decimals.</param>
        /// <param name="fromAccount">Source account, for example <c>SPOT</c>.</param>
        /// <param name="toAccount">Destination account, for example <c>FUTURES</c>.</param>
        /// <param name="ct">Cancellation token.</param>
        Task<HttpResult<PoloniexAccountTransfer>> TransferAsync(string currency, decimal amount,
            string fromAccount, string toAccount, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/account#fee-info" />
        /// </summary>
        Task<HttpResult<PoloniexAccountFee>> GetFeeRatesAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/wallet#wallets-activity-records" />
        /// </summary>
        Task<HttpResult<PoloniexWalletActivity>> GetWalletActivityAsync(DateTime startDate, DateTime endDate, PoloniexWalletActivityType? activityType = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/account#account-activity" />
        /// </summary>
        Task<HttpResult<PoloniexAccountActivity[]>> GetAccountActivityAsync(DateTime? startDate = null, DateTime? endDate = null, PoloniexAccountActivityType? activityType = null, int? limit = null, long? from = null, PoloniexAccountActivityDirection? direction = null, string? asset = null, CancellationToken ct = default);
    }
}
