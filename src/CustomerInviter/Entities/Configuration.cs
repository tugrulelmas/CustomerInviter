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
            CustomerPath = configurationReader.Read("CustomerPath");

            var officeLocationValue = configurationReader.Read("OfficeLocation");

            if (officeLocationValue.IndexOf(',') < 0)
                throw new Exception("Office's location is not correct format. Please write as latitude,longtitude");

            var locations = officeLocationValue.Split(',').Select(x => Convert.ToDouble(x, CultureInfo.InvariantCulture));
            OfficeLocation = new Location(locations.First(), locations.Last());
        }

        public string CustomerPath { get; protected set; }

        public Location OfficeLocation { get; protected set; }

        public virtual double MaxDistance { get; protected set; }
    }
}
