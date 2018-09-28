using CustomerInviter.Implementations;
using Xunit;

namespace CustomerInviter.Test
{
    public class StringShould
    {
        [Theory]
        [InlineData("http://foo")]
        [InlineData("HTTP://FOO/BAR.txt")]
        [InlineData("https://foo")]
        [InlineData("HTTPS://FOO/BAR.txt")]
        public void ReturnTrueForIsHttpUrl(string uri) {
            Assert.True(uri.IsHttpUrl());
        }

        [Theory]
        [InlineData("/home/customer.txt")]
        [InlineData("12HTTP://FOO/BAR.txt")]
        public void ReturnFalseForIsHttpUrl(string uri) {
            Assert.False(uri.IsHttpUrl());
        }
    }
}