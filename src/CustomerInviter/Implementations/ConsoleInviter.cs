using System;
using System.Collections.Generic;
using CustomerInviter.Abstractions;
using CustomerInviter.Entities;

namespace CustomerInviter.Implementations {
    public class ConsoleInviter : IInviter {
        public void Invite (IEnumerable<Customer> customers) {
            if (customers == null)
                throw new ArgumentNullException (nameof (customers));

            foreach (var customerListItem in customers) {
                Console.WriteLine ($"id: {customerListItem.Id}, name: {customerListItem.Name}");
            }
        }
    }
}