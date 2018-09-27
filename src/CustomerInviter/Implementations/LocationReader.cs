using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CustomerInviter.Implementations
{
    public class LocationReader : ILocationReader
    {
        private readonly IFileReaderFactory fileReaderFactory;

        public LocationReader(IFileReaderFactory fileReaderFactory) {
            this.fileReaderFactory = fileReaderFactory;
        }

        public IEnumerable<CustomerLocation> Read(string path) {
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