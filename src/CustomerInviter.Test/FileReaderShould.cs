using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using CustomerInviter.Implementations;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CustomerInviter.Test
{
    public class FileReaderShould
    {
        [Fact]
        public void ThrowFileNotFoundExceptionIfThereIsNoFile() {
            var fileReader = new FileReader(new Mock<IStreamReader>().Object);
            var path = "temp";

            var exception = Assert.Throws<CustomException>(() => fileReader.Read(path));

            Assert.NotNull(exception);
            Assert.Equal(Exceptions.FileNotFound(path).Message, exception.Message);
        }

        [Fact]
        public void ReadFilesOverHttp() {
            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK);
            var content = @"{'latitude': '52.986375', 'user_id': 12, 'name': 'Christina McArdle', 'longitude': '-6.043701'}
                    {'latitude': '51.92893', 'user_id': 1, 'name': 'Alice Cahill', 'longitude': '-10.27699'}
                    {'latitude': '51.8856167', 'user_id': 8, 'name': 'Ian McArdle', 'longitude': '-10.4240951'}";
            httpResponse.Content = new StringContent(content);
            var uri = "temp";

            var httpClient = new Mock<IHttpClient>();
            var fileReader = new HttpFileReader(httpClient.Object, new CustomStreamReader());

            httpClient.Setup(x => x.GetAsync(uri)).Returns(Task.FromResult(httpResponse));

            var result = fileReader.Read(uri);

            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }
    }
}
