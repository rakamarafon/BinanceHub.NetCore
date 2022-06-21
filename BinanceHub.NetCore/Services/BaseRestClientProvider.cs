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

        public async Task<string> SendPublicRequestAsync(string url, HttpMethod httpMethod, Dictionary<string, object>? query = null)
        {
            return await SendRequestAsync(url, httpMethod, query);
        }
       
        private async Task<string> SendRequestAsync(string url, HttpMethod httpMethod, Dictionary<string, object>? query = null)
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
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException(response.StatusCode.ToString());
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
