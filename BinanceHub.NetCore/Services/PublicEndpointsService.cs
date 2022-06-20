using BinanceHub.NetCore.Interfaces;
using BinanceHub.NetCore.Models;

namespace BinanceHub.NetCore.Services
{
    public class PublicEndpointsService : BaseRestClientProvider, IPublicEndpointType
    {
        public PublicEndpointsService(string key, string secret) : base(key, secret)
        {

        }
        public async Task<SystemStatus> GetSystemStatus()
        {
            return await this.SendPublicRequestAsync<SystemStatus>("/sapi/v1/system/status", HttpMethod.Get);
        }      
    }
}
