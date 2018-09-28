using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using CustomerInviter.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CustomerInviter.Test
{
    public class StartupShould
    {
        [Fact]
        public void NotThrowExceptionForKnownExceptions() {
            var startupMock = new Mock<IStartup>();
            var exception = new CustomException("foo");
            startupMock.Setup(x => x.Start()).Throws(exception);

            var startup = new StartupExceptionDecorator(startupMock.Object);
            startup.Start();
        }

        [Fact]
        public void NotThrowExceptionForUnknownExceptions() {
            var startupMock = new Mock<IStartup>();
            var exception = new Exception("foo");
            startupMock.Setup(x => x.Start()).Throws(exception);

            var startup = new StartupExceptionDecorator(startupMock.Object);
            startup.Start();
        }

        [Fact]
        public void NotCallInviteIfThereIsAnException() {
            var inviter = new Mock<IInviter>();
            var configurationReader = new Mock<IConfigurationReader>();
            var customerFinder = new Mock<ICustomerFinder>();
            var startup = new Startup(configurationReader.Object, customerFinder.Object, inviter.Object);

            configurationReader.Setup(x => x.Read("OfficeLocation")).Returns("12,56");
            configurationReader.Setup(x => x.Read<double>("MaxDistance")).Returns(12);
            customerFinder.Setup(x => x.Find(It.IsAny<Configuration>())).Throws(new Exception());

            Assert.Throws<Exception>(() => startup.Start());

            inviter.Verify(x => x.Invite(It.IsAny<IEnumerable<Customer>>()), Times.Never());
        }
    }
}