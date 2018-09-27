using CustomerInviter.Entities;
using System.Collections.Generic;

namespace CustomerInviter.Abstractions
{
    public interface IInviter
    {
        void Invite(IEnumerable<Customer> customers);
    }
}
