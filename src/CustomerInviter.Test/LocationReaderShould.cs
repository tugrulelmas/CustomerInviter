using CustomerInviter.Abstractions;
using CustomerInviter.Test.Stubs;
using Moq;
using System.Linq;
using Xunit;

namespace CustomerInviter.Test
{
    public class LocationReaderShould
    {
        private readonly LocationReaderStub locationReader;

        public LocationReaderShould() {
            locationReader = LocationReaderStub.Create();
        }

        [Fact]
        public void ReadCustomerLocations() {
            var path = "temp";

            var json = new string[]{
            "{'latitude': '52.986375', 'user_id': 12, 'name': 'Christina McArdle', 'longitude': '-6.043701'}",
            "{'latitude': '51.92893', 'user_id': 1, 'name': 'Alice Cahill', 'longitude': '-10.27699'}",
            "{'latitude': '51.8856167', 'user_id': 8, 'name': 'Ian McArdle', 'longitude': '-10.4240951'}"
            };

            var fileReader = new Mock<IFileReader>();
            fileReader.Setup(x => x.Read(path)).Returns(json);
            locationReader.FileReaderFactoryMock.Setup(x => x.GetFileReader(path)).Returns(fileReader.Object);

            var customerlocations = locationReader.Read(path);

            Assert.NotNull(customerlocations);
            Assert.Equal(3, customerlocations.Count());
        }
    }
}
