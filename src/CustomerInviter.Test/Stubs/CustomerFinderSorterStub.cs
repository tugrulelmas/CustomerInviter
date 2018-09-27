using CustomerInviter.Abstractions;
using CustomerInviter.Implementations;
using Moq;

namespace CustomerInviter.Test.Stubs
{
    public class CustomerFinderSorterStub : CustomerFinderSorter
    {
        public Mock<ICustomerFinder> CustomerFinderMock { get; }

        public CustomerFinderSorterStub(Mock<ICustomerFinder> customerFinderMock)
            : base(customerFinderMock.Object) {
            CustomerFinderMock = customerFinderMock;
        }

        public static CustomerFinderSorterStub Create() => new CustomerFinderSorterStub(new Mock<ICustomerFinder>());
    }
}