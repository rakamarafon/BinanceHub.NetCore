using BinanceHub.NetCore.Interfaces;
using Newtonsoft.Json;
using System.Text.Json;

namespace BinanceHub.NetCore.Services
{
    public class BaseRestClientProvider : IBaseRestClientProvider
    {
        private const string BASE_URL = "https://api1.binance.com";
        private readonly string API_KEY;
        private readonly string API_SECRET;

        public BaseRestClientProvider(string api_key, string api_secret)
        {
            API_KEY = api_key;
            API_SECRET = api_secret;
        }

        public async Task<T> GetRequestAsync<T>(string url)
        {
            string requestURL = BASE_URL + url;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestURL);
            
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string contentString = await response.Content.ReadAsStringAsync();
                return ConvertToResultType<T>(contentString);
            }
            else
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
        }

        private T ConvertToResultType<T>(string source)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            try
            {
                var result = JsonConvert.DeserializeObject<T>(source);
                if (result == null)
                    throw new Exception($"cannot convert respons to {typeof(T)}");
                return result; 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
