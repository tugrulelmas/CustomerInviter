using System.Collections.Generic;
using System.IO;

namespace CustomerInviter.Abstractions
{
    public interface IStreamReader
    {
        IEnumerable<string> ReadByline(Stream stream);
    }
}
