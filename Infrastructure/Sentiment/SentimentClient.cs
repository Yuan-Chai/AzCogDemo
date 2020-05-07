using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Sentiment
{
    public interface ISentimentClient : IHttpClient
    {

    }

    public class SentimentClient: ISentimentClient
    {
        private readonly HttpClient _httpClient;
        private readonly SentimentClientOptions _options;

        public SentimentClient(HttpClient httpClient, IOptions<SentimentClientOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<T> PostAync<T>(string content)
        {
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _options.SubscriptionKey);

            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse = await _httpClient.PostAsync(new Uri(_options.EndpointUrl), httpContent);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.StatusCode.Equals(HttpStatusCode.OK) || httpResponse.Content == null)
            {
                throw new Exception(responseContent);
            }

            return JsonConvert.DeserializeObject<T>(responseContent, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
