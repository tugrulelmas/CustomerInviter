using CustomerInviter.Abstractions;
using System;
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
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri) {
            var response = await client.GetAsync(requestUri);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"could not get via {requestUri}");

            return response;
        }
    }
}