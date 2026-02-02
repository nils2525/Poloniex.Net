namespace Poloniex.Net.Objects
{
    /// <summary>
    /// Api addresses
    /// </summary>
    public class PoloniexApiAddresses
    {
        /// <summary>
        /// The address used by the CryptoComRestClient for the API
        /// </summary>
        public string RestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the CryptoComSocketClient for the websocket API
        /// </summary>
        public string SocketClientPublicAddress { get; set; } = "";

        /// <summary>
        /// The default addresses to connect to the CryptoCom API
        /// </summary>
        public static PoloniexApiAddresses Default = new PoloniexApiAddresses
        {
            RestClientAddress = "https://api.poloniex.com",
            SocketClientPublicAddress = "wss://ws.poloniex.com/ws",
        };
    }
}
