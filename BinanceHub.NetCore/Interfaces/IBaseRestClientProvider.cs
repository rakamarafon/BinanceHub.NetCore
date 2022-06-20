namespace BinanceHub.NetCore.Interfaces
{
    public interface IBaseRestClientProvider
    {
        public Task<T> GetRequestAsync<T>(string url);
    }
}
