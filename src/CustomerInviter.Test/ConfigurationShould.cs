using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using Moq;
using Xunit;

namespace CustomerInviter.Test
{
    public class ConfigurationShould
    {
        [Fact]
        public void ShouldThrowOfficeLocationIncorrectFormat() {
            var configurationReader = new Mock<IConfigurationReader>();
            var location = "foo";
            configurationReader.Setup(x => x.Read("OfficeLocation")).Returns(location);

            var exception = Assert.Throws<CustomException>(() => new Configuration(configurationReader.Object));

            Assert.NotNull(exception);
            Assert.Equal(Exceptions.OfficeLocationIncorrectFormat(location).Message, exception.Message);
        }

        [Fact]
        public void ShouldSetCorrectOfficeLocation() {
            var configurationReader = new Mock<IConfigurationReader>();
            var location = "12,-68";
            configurationReader.Setup(x => x.Read("OfficeLocation")).Returns(location);

            var configuration = new Configuration(configurationReader.Object);

            Assert.NotNull(configuration.OfficeLocation);
            Assert.Equal(12, configuration.OfficeLocation.Latitude);
            Assert.Equal(-68, configuration.OfficeLocation.Longitude);
        }
    }
}