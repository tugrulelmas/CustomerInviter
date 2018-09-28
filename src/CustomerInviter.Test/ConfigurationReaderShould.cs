using CustomerInviter.Entities;
using CustomerInviter.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CustomerInviter.Test
{
    public class ConfigurationReaderShould
    {
        [Fact]
        public void ShouldThrowKeyIsEmptyIfTheValueIsEmpty() {
            var key = "foo";
            var configurationReader = new ConfigurationReader(new ConfigurationTest(new Dictionary<string, string>() { { key, string.Empty } }));

            var exception = Assert.Throws<CustomException>(() => configurationReader.Read(key));

            Assert.NotNull(exception);
            Assert.Equal(Exceptions.KeyIsEmpty(key).Message, exception.Message);
        }

        [Fact]
        public void ShouldSetCorrectValue() {
            var key = "foo";
            var configurationReader = new ConfigurationReader(new ConfigurationTest(new Dictionary<string, string>() { { key, "6.12" } }));

            var result = configurationReader.Read<double>(key);

            Assert.Equal(6.12D, result);
        }

        private class ConfigurationTest : IConfiguration
        {
            private readonly IDictionary<string, string> maps;

            public ConfigurationTest(IDictionary<string, string> maps) {
                this.maps = maps;
            }

            public string this[string key] { get { return maps[key]; } set { maps[key] = value; } }

            public IEnumerable<IConfigurationSection> GetChildren() => new Mock<IEnumerable<IConfigurationSection>>().Object;

            public IChangeToken GetReloadToken() => new Mock<IChangeToken>().Object;

            public IConfigurationSection GetSection(string key) {
                var section = new Mock<IConfigurationSection>();
                section.Setup(x => x.Key).Returns(key);
                section.Setup(x => x.Value).Returns(maps[key]);
                return section.Object;
            }
        }
    }
}