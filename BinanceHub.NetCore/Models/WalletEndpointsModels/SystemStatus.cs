using Newtonsoft.Json;

namespace BinanceHub.NetCore.Models.WalletEndpointsModels
{
    public class SystemStatus
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
        [JsonProperty(PropertyName = "msg")]
        public string Message { get; set; } = string.Empty;
    }
}
