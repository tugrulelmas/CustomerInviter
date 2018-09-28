using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System.Collections.Generic;
using System.IO;

namespace CustomerInviter.Implementations
{
    public class FileReader : IFileReader
    {
        private readonly IStreamReader streamReader;

        public FileReader(IStreamReader streamReader) {
            this.streamReader = streamReader;
        }

        public bool CanRead(string path) => !path.IsHttpUrl();

        public IEnumerable<string> Read(string path) {
            if (!File.Exists(path))
                throw Exceptions.FileNotFound(path);

            return streamReader.ReadByline(new FileStream(path, FileMode.Open));
        }
    }
}