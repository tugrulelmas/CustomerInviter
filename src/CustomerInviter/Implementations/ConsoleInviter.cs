using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System;
using System.Collections.Generic;

namespace CustomerInviter.Implementations
{
    public class ConsoleInviter : IInviter
    {
        public void Invite(IEnumerable<Customer> customers) {
            foreach (var customerListItem in customers) {
                Console.WriteLine($"id: {customerListItem.Id}, name: {customerListItem.Name}");
            }
        }
    }
}
