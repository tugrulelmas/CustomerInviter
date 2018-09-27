using System.Collections.Generic;

namespace CustomerInviter.Abstractions
{
    public interface IFileReader
    {
        bool CanRead(string path);

        IEnumerable<string> Read(string path);
    }
}
