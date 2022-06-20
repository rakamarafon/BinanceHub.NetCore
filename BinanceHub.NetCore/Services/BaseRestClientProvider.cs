using BinanceHub.NetCore.Interfaces;
using Newtonsoft.Json;
using System.Text;
using System.Web;

namespace BinanceHub.NetCore.Services
{
    public class BaseRestClientProvider : IBaseRestClientProvider
    {
        private const string BASE_URL = "https://api.binance.com";
        private readonly string API_KEY;
        private readonly string API_SECRET;

        public BaseRestClientProvider(string api_key, string api_secret)
        {
            API_KEY = api_key;
            API_SECRET = api_secret;
        }

        public async Task<T> SendPublicRequestAsync<T>(string url, HttpMethod httpMethod, Dictionary<string, object>? query = null)
        {
            return await SendRequestAsync<T>(url, httpMethod, query);
        }
       
        private async Task<T> SendRequestAsync<T>(string url, HttpMethod httpMethod, Dictionary<string, object>? query = null)
        {
            string requestURL = string.Empty;                        
            string queryString = GenerateQueryString(query);
            
            if(string.IsNullOrEmpty(queryString))
            {
                requestURL = BASE_URL + url;
            } else
            {
                requestURL = BASE_URL + url + "?" + queryString;
            }

            HttpRequestMessage request = new HttpRequestMessage(httpMethod, requestURL);
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
            if (source == null)
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

        private string GenerateQueryString(Dictionary<string, object>? query)
        {
            if(query == null)
            {
                return string.Empty;
            }

            StringBuilder builder = new StringBuilder();

            foreach (var item in query)
            {
                var value = item.Value.ToString();
                if(!string.IsNullOrEmpty(value))
                {
                   if(builder.Length > 0)
                   {
                    builder.Append("&");
                   }

                   builder
                    .Append(item.Key)
                    .Append("=")
                    .Append(HttpUtility.UrlEncode(value));
                }
            }
            return builder.ToString();
        }
    }
}
