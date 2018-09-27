using CustomerInviter.Entities;
using System.Collections.Generic;

namespace CustomerInviter.Abstractions
{
    public interface ICustomerFinder
    {
        IEnumerable<Customer> Find();
    }
}