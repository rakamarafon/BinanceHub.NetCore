using Newtonsoft.Json;

namespace BinanceHub.NetCore.Models
{
    public class ServerTime
    {
        [JsonProperty("serverTime")]
        public long Timestamp { get; set; }
    }
}
