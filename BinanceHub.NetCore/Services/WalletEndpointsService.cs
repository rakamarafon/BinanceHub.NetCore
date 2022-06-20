using BinanceHub.NetCore.Interfaces;
using BinanceHub.NetCore.Models.WalletEndpointsModels;

namespace BinanceHub.NetCore.Services
{
    internal class WalletEndpointsService : BaseEndpointsService, IWalletEndpoints
    {
        public WalletEndpointsService(string api_key, string api_secret) : base(api_key, api_secret)
        {
        }

        public async Task<SystemStatus> GetSystemStatusAsync()
        {
           return await this.GetRequestAsync<SystemStatus>("/sapi/v1/system/status");
        }
    }
}
