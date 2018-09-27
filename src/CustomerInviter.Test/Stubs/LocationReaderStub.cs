using CustomerInviter.Abstractions;
using CustomerInviter.Implementations;
using Moq;

namespace CustomerInviter.Test.Stubs
{
    public class LocationReaderStub : LocationReader
    {
        public readonly Mock<IFileReaderFactory> FileReaderFactoryMock;

        public LocationReaderStub(Mock<IFileReaderFactory> fileReaderFactory)
            : base(fileReaderFactory.Object) {
            FileReaderFactoryMock = fileReaderFactory;
        }

        public static LocationReaderStub Create() => new LocationReaderStub(new Mock<IFileReaderFactory>());
    }
}