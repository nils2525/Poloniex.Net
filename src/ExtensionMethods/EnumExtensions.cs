using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoExchange.Net.Objects;
using Poloniex.Net.Enums;

namespace Poloniex.Net.ExtensionMethods
{
    internal static class EnumExtensions
    {
        public static SocketUpdateType ToCEN(this PoloniexSocketAction action)
            => action switch
            {
                PoloniexSocketAction.Update => SocketUpdateType.Update,
                PoloniexSocketAction.Snapshot => SocketUpdateType.Snapshot,
                _ => throw new ArgumentException($"Unknown action type ({action})"),
            };

        public static string ToFuturesValue(this PoloniexTradeSide side)
            => side switch
            {
                PoloniexTradeSide.Buy => "BUY",
                PoloniexTradeSide.Sell => "SELL",
                _ => throw new ArgumentException($"Unknown trade side ({side})"),
            };

        public static string ToFuturesValue(this PoloniexPageDirection direction)
            => direction switch
            {
                PoloniexPageDirection.Previous => "PREV",
                PoloniexPageDirection.Next => "NEXT",
                _ => throw new ArgumentException($"Unknown page direction ({direction})"),
            };
    }
}
