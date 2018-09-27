using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using CustomerInviter.Test.Stubs;
using System;
using Xunit;

namespace CustomerInviter.Test
{
    public class DistanceCalculatorShould
    {
        private readonly IDistanceCalculator distanceCalculator;

        public DistanceCalculatorShould() {
            distanceCalculator = DistanceCalculatorStub.Create();
        }

        [Theory]
        [InlineData(12, 13)]
        [InlineData(-1, 0)]
        public void CalculateDistanceAs111KmBetweenTwoMeridians(int fromLatitude, int toLatitude) {
            var from = new Location(fromLatitude, 0);
            var to = new Location(toLatitude, 0);

            var result = distanceCalculator.CalculateDistanceAsKm(from, to);

            Assert.Equal(111.19, Math.Round(result, 2));
        }
        
        [Fact]
        public void CalculateDistanceAs111KmBetweenTwoMeridians2() {
            var from = new Location(52.986375, -6.043701);
            var to = new Location(53.339428, -6.257664);

            var result = distanceCalculator.CalculateDistanceAsKm(from, to);

            Assert.Equal(41.77, Math.Round(result, 2));
        }
    }
}
