using CustomerInviter.Entities;
using CustomerInviter.Test.Stubs;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomerInviter.Test
{
    public class CustomerFinderShould
    {
        private readonly CustomerFinderStub customerFinder;

        public CustomerFinderShould() {
            customerFinder = CustomerFinderStub.Create();
        }

        [Fact]
        public void FindCustomersWhoAreAtTheDesiredDistance() {
            var customerLocation1 = new CustomerLocation(new Customer(12, "foo"), new Location(60, 124));
            var customerLocation2 = new CustomerLocation(new Customer(13, "bar"), new Location(62, 125));
            var customerLocation3 = new CustomerLocation(new Customer(14, "foobar"), new Location(70, 126));
            var customerLocations = new List<CustomerLocation> {
                customerLocation1,
                customerLocation2,
                customerLocation3
            };
            var configuration = new Mock<Configuration>();
            configuration.Setup(x => x.MaxDistance).Returns(20);

            customerFinder.LocationReaderMock.Setup(x => x.Read(It.IsAny<string>())).Returns(customerLocations);
            customerFinder.DistanceCalculatorMock.Setup(x => x.GetBoundingRectangle(20, It.IsAny<Location>())).Returns(new BoundingRectangle(new Location(-90, -180), new Location(90, 180)));
            customerFinder.DistanceCalculatorMock.Setup(x => x.CalculateDistanceAsKm(customerLocation1.Location, configuration.Object.OfficeLocation)).Returns(configuration.Object.MaxDistance - 10);
            customerFinder.DistanceCalculatorMock.Setup(x => x.CalculateDistanceAsKm(customerLocation2.Location, configuration.Object.OfficeLocation)).Returns(configuration.Object.MaxDistance + 10);
            customerFinder.DistanceCalculatorMock.Setup(x => x.CalculateDistanceAsKm(customerLocation3.Location, configuration.Object.OfficeLocation)).Returns(configuration.Object.MaxDistance - 5);

            var customers = customerFinder.Find(configuration.Object);

            Assert.NotNull(customers);
            Assert.Equal(2, customers.Count());
            Assert.DoesNotContain(customers, x => x.Id == customerLocation2.Customer.Id);
        }
    }
}
