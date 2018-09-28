using CustomerInviter.Abstractions;
using CustomerInviter.Entities;

namespace CustomerInviter.Implementations
{
    public class Startup : IStartup
    {
        private readonly IConfigurationReader configurationReader;
        private readonly ICustomerFinder customerFinder;
        private readonly IInviter inviter;

        public Startup(IConfigurationReader configurationReader, ICustomerFinder customerFinder, IInviter inviter)
        {
            this.configurationReader = configurationReader;
            this.customerFinder = customerFinder;
            this.inviter = inviter;
        }

        public void Start()
        {
            var configuration = new Configuration(configurationReader);
            var customers = customerFinder.Find(configuration);
            inviter.Invite(customers);
        }
    }
}