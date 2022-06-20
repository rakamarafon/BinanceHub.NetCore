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
        public async Task<DateTime> CheckServerTime()
        {
            var serverTime = await this.SendPublicRequestAsync<ServerTime>("/api/v3/time", HttpMethod.Get);
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddMilliseconds(serverTime.Timestamp)
                            .ToLocalTime();
        }
    }
}
