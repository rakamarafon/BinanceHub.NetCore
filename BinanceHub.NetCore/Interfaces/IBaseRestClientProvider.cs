namespace BinanceHub.NetCore.Interfaces
{
    public interface IBaseRestClientProvider
    {
        public Task<T> SendPublicRequestAsync<T>(string url, HttpMethod httpMethod, Dictionary<string, object>? query = null);
    }
}
