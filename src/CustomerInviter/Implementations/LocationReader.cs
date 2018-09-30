using System;
using System.Collections.Generic;
using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using Newtonsoft.Json;

namespace CustomerInviter.Implementations {
    public class LocationReader : ILocationReader {
        private readonly IFileReaderFactory fileReaderFactory;

        public LocationReader (IFileReaderFactory fileReaderFactory) {
            this.fileReaderFactory = fileReaderFactory;
        }

        public IEnumerable<CustomerLocation> Read (string path) {
            var fileReader = fileReaderFactory.GetFileReader (path);
            var lines = fileReader.Read (path);
            foreach (var lineItem in lines) {
                CustomerDto customerDto;
                try {
                    customerDto = JsonConvert.DeserializeObject<CustomerDto> (lineItem);
                } catch (Exception ex) {
                    throw Exceptions.InvalidJsonData (ex.Message);
                }
                yield return customerDto.ToUserLocation ();
            }
        }

        private class CustomerDto {
            public int user_id { get; set; }

            public string name { get; set; }

            public double latitude { get; set; }

            public double longitude { get; set; }

            public CustomerLocation ToUserLocation () => new CustomerLocation (new Customer (user_id, name), new Location (latitude, longitude));
        }
    }
}