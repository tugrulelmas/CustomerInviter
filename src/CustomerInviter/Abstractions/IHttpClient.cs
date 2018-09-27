using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerInviter.Abstractions
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
