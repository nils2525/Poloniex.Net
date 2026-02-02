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
    }
}
