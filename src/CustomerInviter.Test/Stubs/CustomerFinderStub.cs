using CustomerInviter.Abstractions;
using CustomerInviter.Implementations;
using Moq;

namespace CustomerInviter.Test.Stubs
{
    public class CustomerFinderStub : CustomerFinder
    {
        public readonly Mock<ILocationReader> LocationReaderMock;
        public readonly Mock<IDistanceCalculator> DistanceCalculatorMock;

        public CustomerFinderStub(Mock<ILocationReader> locationReader, Mock<IDistanceCalculator> distanceCalculator)
            : base(locationReader.Object, distanceCalculator.Object) {
            LocationReaderMock = locationReader;
            DistanceCalculatorMock = distanceCalculator;
        }

        public static CustomerFinderStub Create() => new CustomerFinderStub(new Mock<ILocationReader>(), new Mock<IDistanceCalculator>());
    }
}