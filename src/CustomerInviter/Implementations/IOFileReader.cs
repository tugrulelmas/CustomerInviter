using CustomerInviter.Abstractions;
using System.Collections.Generic;
using System.IO;

namespace CustomerInviter.Implementations
{
    public class IOFileReader : IFileReader
    {
        private readonly IStreamReader streamReader;

        public IOFileReader(IStreamReader streamReader) {
            this.streamReader = streamReader;
        }

        public bool CanRead(string path) => !path.IsHttpUrl();

        public IEnumerable<string> Read(string path) => streamReader.ReadByline(new FileStream(path, FileMode.Open));
    }
}
