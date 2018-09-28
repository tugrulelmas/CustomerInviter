using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomerInviter.Implementations
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient client;

        public CustomHttpClient() {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri) {
            var response = await client.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
                throw Exceptions.HttpGet(requestUri, await response.Content.ReadAsStringAsync());

            return response;
        }
    }
}