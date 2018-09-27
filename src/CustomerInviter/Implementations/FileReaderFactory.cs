using CustomerInviter.Abstractions;
using System.Collections.Generic;
using System.Linq;

namespace CustomerInviter.Implementations
{
    public class FileReaderFactory : IFileReaderFactory
    {
        private readonly IEnumerable<IFileReader> fileReaders;

        public FileReaderFactory(IEnumerable<IFileReader> fileReaders) {
            this.fileReaders = fileReaders;
        }

        public IFileReader GetFileReader(string path) => fileReaders.First(x => x.CanRead(path));
    }
}
