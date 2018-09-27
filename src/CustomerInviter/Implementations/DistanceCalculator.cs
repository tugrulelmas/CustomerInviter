using CustomerInviter.Abstractions;
using CustomerInviter.Entities;
using System;

namespace CustomerInviter.Implementations
{
    public class DistanceCalculator : IDistanceCalculator
    {
        private static readonly int R = 6371;

        public double CalculateDistanceAsKm(Location from, Location to) {
            var fromLatitude = from.Latitude.ToRadians();
            var toLatitude = to.Latitude.ToRadians();
            var theta = (to.Longitude - from.Longitude).ToRadians();
            var centralAngle = Math.Acos((Math.Sin(fromLatitude) * Math.Sin(toLatitude))
                               + (Math.Cos(fromLatitude) * Math.Cos(toLatitude) * Math.Cos(theta)));
            var result = centralAngle * R;
            return result;
        }
    }

    public static class DistanceCalculatorExtensions
    {
        public static double ToRadians(this double value) => value * Math.PI / 180;
    }
}
