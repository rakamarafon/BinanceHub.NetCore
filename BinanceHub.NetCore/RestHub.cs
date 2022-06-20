using BinanceHub.NetCore.Interfaces;
using BinanceHub.NetCore.Services;

namespace BinanceHub.NetCore
{
    public class RestHub
    {
        public IPublicEndpointType PublicAPI { get; set; }
        public ITradeEndpointType TradeAPI { get; set; }
        public IMarginEndpointType MarginAPI { get; set; }
        public IUserDataEndpointType UserDataAPI { get; set; }

        public RestHub(string api_key, string api_secret)
        {
           PublicAPI = new PublicEndpointsService(api_key, api_secret); 
        }
    }
}
