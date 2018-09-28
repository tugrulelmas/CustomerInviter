using CustomerInviter.Abstractions;
using System;
using System.Globalization;
using System.Linq;

namespace CustomerInviter.Entities
{
    public class Configuration
    {
        protected Configuration() {

        }

        public Configuration(IConfigurationReader configurationReader) {
            MaxDistance = configurationReader.Read<double>("MaxDistance");
            if (MaxDistance <= 0)
                throw Exceptions.MaxDistanceShouldBePositive();

            CustomerPath = configurationReader.Read("CustomerPath");

            var officeLocationValue = configurationReader.Read("OfficeLocation");

            if (officeLocationValue.IndexOf(',') < 0)
                throw Exceptions.OfficeLocationIncorrectFormat(officeLocationValue);

            try {
                var locations = officeLocationValue.Split(',').Select(x => Convert.ToDouble(x.Trim(), CultureInfo.InvariantCulture));
                OfficeLocation = new Location(locations.First(), locations.Last());
            } catch {
                throw Exceptions.OfficeLocationIncorrectFormat(officeLocationValue);
            }
        }

        public string CustomerPath { get; protected set; }

        public Location OfficeLocation { get; protected set; }

        public virtual double MaxDistance { get; protected set; }
    }
}
