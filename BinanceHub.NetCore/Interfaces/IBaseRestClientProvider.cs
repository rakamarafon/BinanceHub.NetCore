namespace BinanceHub.NetCore.Interfaces
{
    public interface IBaseRestClientProvider
    {
        public Task<string> SendPublicRequestAsync(string url, HttpMethod httpMethod, Dictionary<string, object>? query = null);
    }
}
