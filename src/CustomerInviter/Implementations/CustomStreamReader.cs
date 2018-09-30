using CustomerInviter.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomerInviter.Implementations
{
    public class CustomStreamReader : IStreamReader
    {
        public IEnumerable<string> ReadByline(Stream stream) {
            if (stream == null)
                throw new ArgumentNullException (nameof (stream));

            string line;
            using (StreamReader streamReader = new StreamReader(stream)) {
                while ((line = streamReader.ReadLine()) != null) {
                     yield return line;
                }
            }
        }
    }
}
