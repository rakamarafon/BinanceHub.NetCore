using BinanceHub.NetCore.Interfaces.Endpoints;
using BinanceHub.NetCore.Services.Endpoints;

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
