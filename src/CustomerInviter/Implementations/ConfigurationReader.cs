using CustomerInviter.Abstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;

namespace CustomerInviter.Implementations
{
    public class ConfigurationReader : IConfigurationReader
    {
        private readonly IConfiguration configuration;

        public ConfigurationReader(IConfiguration configuration) {
            this.configuration = configuration;
        }

        public string Read(string key) {
            var result = configuration.GetValue<string>(key);
            if(string.IsNullOrWhiteSpace(result))
                throw new Exception($"The key with name {key} is empty.");

            return result;
        }

        public T Read<T>(string key) {
            var value = Read(key);
            try {
                return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            } catch {
                throw new Exception($"The key with name {key} is in incorrect format.");
            }
        }
    }
}