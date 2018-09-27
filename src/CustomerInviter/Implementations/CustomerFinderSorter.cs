using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System.Collections.Generic;

namespace CustomerInviter.Implementations
{
    public class CustomerFinderSorter : ICustomerFinder
    {
        private readonly ICustomerFinder customerFinder;

        public CustomerFinderSorter(ICustomerFinder customerFinder) {
            this.customerFinder = customerFinder;
        }

        public IEnumerable<Customer> Find(Configuration configuration) {
            var customerList = new SortedDictionary<int, Customer>();
            var unsortedList = customerFinder.Find(configuration);
            foreach (var unsortedListItem in unsortedList) {
                customerList.Add(unsortedListItem.Id, unsortedListItem);
            }

            foreach (var customerListItem in customerList) {
                yield return customerListItem.Value;
            }
        }
    }
}