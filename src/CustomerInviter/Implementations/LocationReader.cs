using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CustomerInviter.Implementations
{
    public class LocationReader : ILocationReader
    {
        private readonly IFileReaderFactory fileReaderFactory;
        private readonly IConfigurationReader configurationReader;

        public LocationReader(IFileReaderFactory fileReaderFactory, IConfigurationReader configurationReader) {
            this.fileReaderFactory = fileReaderFactory;
            this.configurationReader = configurationReader;
        }

        public IEnumerable<CustomerLocation> Read() {
            var path = configurationReader.Read(Configurations.CustomerPath);
            if (string.IsNullOrWhiteSpace(path))
                throw new Exception("Customer path is empty");

            var fileReader = fileReaderFactory.GetFileReader(path);
            var lines = fileReader.Read(path);
            foreach (var lineItem in lines) {
                var customerDto = JsonConvert.DeserializeObject<CustomerDto>(lineItem);
                yield return customerDto.ToUserLocation();
            }
        }

        private class CustomerDto
        {
            public int user_id { get; set; }

            public string name { get; set; }

            public double latitude { get; set; }

            public double longitude { get; set; }

            public CustomerLocation ToUserLocation() => new CustomerLocation(new Customer(user_id, name), new Location(latitude, longitude));
        }
    }
}