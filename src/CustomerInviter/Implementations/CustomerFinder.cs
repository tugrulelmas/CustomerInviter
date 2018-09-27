using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CustomerInviter.Implementations
{
    public class CustomerFinder : ICustomerFinder
    {
        private readonly ILocationReader locationReader;
        private readonly IDistanceCalculator distanceCalculator;
        private readonly Location officeLocation;
        private readonly double maxDistance;

        public CustomerFinder(ILocationReader locationReader, IDistanceCalculator distanceCalculator, IConfigurationReader configurationReader) {
            this.locationReader = locationReader;
            this.distanceCalculator = distanceCalculator;
            maxDistance = configurationReader.Read<double>(Configurations.MaxDistance);
            var officeLocationValue = configurationReader.Read(Configurations.OfficeLocation);

            if (officeLocationValue.IndexOf(',') < 0)
                throw new Exception("Office's location is not correct format. Please write as latitude,longtitude");

            // TODO: check this

            var locations = officeLocationValue.Split(',').Select(x => Convert.ToDouble(x, CultureInfo.InvariantCulture));
            officeLocation = new Location(locations.First(), locations.Last());
        }

        public IEnumerable<Customer> Find() {
            var customerLocations = locationReader.Read();
            foreach (var customerLocationItem in customerLocations) {
                var distance = distanceCalculator.CalculateDistanceAsKm(customerLocationItem.Location, officeLocation);
                if (distance > maxDistance)
                    continue;

                yield return customerLocationItem.Customer;
            }
        }
    }
}