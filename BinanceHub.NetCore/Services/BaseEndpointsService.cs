namespace BinanceHub.NetCore.Services
{
    public class BaseEndpointsService : BaseRestClientProvider
    {
        public BaseEndpointsService(string api_key, string api_secret) : base(api_key, api_secret)
        {

        }
    }
}
