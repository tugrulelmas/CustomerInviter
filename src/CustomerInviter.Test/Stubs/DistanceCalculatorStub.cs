using CustomerInviter.Implementations;

namespace CustomerInviter.Test.Stubs
{
    public class DistanceCalculatorStub : DistanceCalculator
    {
        public static DistanceCalculatorStub Create() => new DistanceCalculatorStub();
    }
}
