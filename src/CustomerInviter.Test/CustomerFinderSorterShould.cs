using CustomerInviter.Entities;
using CustomerInviter.Test.Stubs;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CustomerInviter.Test
{
    public class CustomerFinderSorterShould
    {
        private readonly CustomerFinderSorterStub customerFinderSorter;

        public CustomerFinderSorterShould() {
            customerFinderSorter = CustomerFinderSorterStub.Create();
        }

        [Fact]
        public void SortInnerList() {
            IEnumerable<Customer> unsortedList = new List<Customer> {
                new Customer(12, "Christina"),
                new Customer(1, "Alice"),
                new Customer(8, "Jack"),
                new Customer(16, "Nora"),
            };

            customerFinderSorter.CustomerFinderMock.Setup(x => x.Find()).Returns(unsortedList);

            var result = customerFinderSorter.Find();

            var sortedList = unsortedList.OrderBy(x => x.Id);

            Assert.Equal(sortedList, result);
        }
    }
}
