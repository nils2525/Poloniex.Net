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
        Task<WebCallResult<PoloniexAccount[]>> GetAccountDetailsAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/account#all-account-balances" />
        /// </summary>
        Task<WebCallResult<PoloniexAccountBalance[]>> GetAccountBalancesAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/account#fee-info" />
        /// </summary>
        Task<WebCallResult<PoloniexAccountFee>> GetFeeRatesAsync(CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/wallet#wallets-activity-records" />
        /// </summary>
        Task<WebCallResult<PoloniexWalletActivity>> GetWalletActivityAsync(DateTime startDate, DateTime endDate, PoloniexWalletActivityType? activityType = null, CancellationToken ct = default);

        /// <summary>
        /// <a href="https://api-docs.poloniex.com/spot/api/private/account#account-activity" />
        /// </summary>
        Task<WebCallResult<PoloniexAccountActivity[]>> GetAccountActivityAsync(DateTime? startDate = null, DateTime? endDate = null, PoloniexAccountActivityType? activityType = null, int? limit = null, long? from = null, PoloniexAccountActivityDirection? direction = null, string? asset = null, CancellationToken ct = default);
    }
}
