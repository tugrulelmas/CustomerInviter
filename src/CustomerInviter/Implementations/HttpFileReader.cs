using CustomerInviter.Abstractions;
using System.Collections.Generic;

namespace CustomerInviter.Implementations
{
    public class HttpFileReader : IFileReader
    {
        private readonly IHttpClient httpClient;
        private readonly IStreamReader streamReader;

        public HttpFileReader(IHttpClient httpClient, IStreamReader streamReader) {
            this.httpClient = httpClient;
            this.streamReader = streamReader;
        }

        public bool CanRead(string path) => path.IsHttpUrl();

        public IEnumerable<string> Read(string path) {
            var response = httpClient.GetAsync(path).Result;
            var stream = response.Content.ReadAsStreamAsync().Result;
            return streamReader.ReadByline(stream);
        }
    }
}
