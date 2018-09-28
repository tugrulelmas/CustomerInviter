using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using CustomerInviter.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace CustomerInviter
{
    internal class Program
    {
        private static void Main(string[] args) {
            var serviceProvider = RegisterServices(args);

            var startup = serviceProvider.GetService<IStartup>();
            startup.Start();

            Console.ReadLine();
        }

        private static ServiceProvider RegisterServices(string[] args) {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            IServiceCollection services = new ServiceCollection();

            return services
                .AddOptions()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<IConfigurationReader, ConfigurationReader>()
                .AddSingleton<IHttpClient, CustomHttpClient>()
                .AddSingleton<IDistanceCalculator, DistanceCalculator>()
                .AddSingleton<IInviter, ConsoleInviter>()
                .AddSingleton<IStreamReader, CustomStreamReader>()
                .AddSingleton<IFileReader, IOFileReader>()
                .AddSingleton<IFileReader, HtmlFileReader>()
                .AddSingleton<IFileReaderFactory, FileReaderFactory>()
                .AddSingleton<ILocationReader, LocationReader>()
                .AddSingleton<ICustomerFinder, CustomerFinderSorter>(x => new CustomerFinderSorter(new CustomerFinder(x.GetService<ILocationReader>(), x.GetService<IDistanceCalculator>())))
                .AddSingleton<IStartup, Startup>()
                .BuildServiceProvider();
        }
    }
}