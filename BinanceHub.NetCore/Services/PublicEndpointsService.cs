using BinanceHub.NetCore.Interfaces;
using BinanceHub.NetCore.Models;
using Newtonsoft.Json;

namespace BinanceHub.NetCore.Services
{
    public class PublicEndpointsService : BaseRestClientProvider, IPublicEndpointType
    {
        public PublicEndpointsService(string key, string secret) : base(key, secret)
        {

        }        

        public async Task<SystemStatus> GetSystemStatus()
        {
            var result = await this.SendPublicRequestAsync("/sapi/v1/system/status", HttpMethod.Get);
            return JsonConvert.DeserializeObject<SystemStatus>(result);
        }
        public async Task<DateTime> CheckServerTime()
        {
            var result = await this.SendPublicRequestAsync("/api/v3/time", HttpMethod.Get);
            var serverTime = JsonConvert.DeserializeObject<ServerTime>(result);
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddMilliseconds(serverTime.Timestamp)
                            .ToLocalTime();
        }
    }
}
