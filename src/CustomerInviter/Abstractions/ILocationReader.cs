using CustomerInviter.Entities;
using System.Collections.Generic;

namespace CustomerInviter.Abstractions
{
    public interface ILocationReader
    {
        IEnumerable<CustomerLocation> Read(string path);
    }
}
