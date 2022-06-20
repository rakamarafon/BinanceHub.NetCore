using BinanceHub.NetCore.Interfaces.Endpoints;
using BinanceHub.NetCore.Models.WalletEndpointsModels;

namespace BinanceHub.NetCore.Services.Endpoints
{
    internal class WalletEndpointsService : BaseEndpointsService, IWalletEndpoints
    {
        public WalletEndpointsService(string api_key, string api_secret) : base(api_key, api_secret)
        {
        }

        public async Task<SystemStatus> GetSystemStatusAsync()
        {
            return await SendPublicRequestAsync<SystemStatus>("/sapi/v1/system/status", HttpMethod.Get);
        }
    }
}
