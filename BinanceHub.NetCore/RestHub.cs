using BinanceHub.NetCore.Interfaces;
using BinanceHub.NetCore.Services;

namespace BinanceHub.NetCore
{
    public class RestHub
    {
        public IWalletEndpoints WalletAPI { get; set; }

        public RestHub(string api_key, string api_secret)
        {
            WalletAPI = new WalletEndpointsService(api_key, api_secret);
        }
    }
}
