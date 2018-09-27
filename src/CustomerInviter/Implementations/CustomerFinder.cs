using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System.Collections.Generic;

namespace CustomerInviter.Implementations
{
    public class CustomerFinder : ICustomerFinder
    {
        private readonly ILocationReader locationReader;
        private readonly IDistanceCalculator distanceCalculator;

        public CustomerFinder(ILocationReader locationReader, IDistanceCalculator distanceCalculator) {
            this.locationReader = locationReader;
            this.distanceCalculator = distanceCalculator;
        }

        public IEnumerable<Customer> Find(Configuration configuration) {
            var customerLocations = locationReader.Read(configuration.CustomerPath);
            foreach (var customerLocationItem in customerLocations) {
                var distance = distanceCalculator.CalculateDistanceAsKm(customerLocationItem.Location, configuration.OfficeLocation);
                if (distance > configuration.MaxDistance)
                    continue;

                yield return customerLocationItem.Customer;
            }
        }
    }
}