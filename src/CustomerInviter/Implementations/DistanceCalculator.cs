using System;
using CustomerInviter.Abstractions;
using CustomerInviter.Entities;

namespace CustomerInviter.Implementations {
    public class DistanceCalculator : IDistanceCalculator {
        private static double MIN_LAT = -90d.ToRadians (); // -PI/2

        private static double MAX_LAT = 90d.ToRadians (); //  PI/2

        private static double MIN_LON = -180d.ToRadians (); // -PI

        private static double MAX_LON = 180d.ToRadians (); //  PI

        private static readonly int R = 6371;

        public double CalculateDistanceAsKm (Location from, Location to) {
            if (from == null)
                throw new ArgumentNullException (nameof (from));

            if (to == null)
                throw new ArgumentNullException (nameof (to));

            var fromLatitude = from.Latitude.ToRadians ();
            var toLatitude = to.Latitude.ToRadians ();
            var theta = (to.Longitude - from.Longitude).ToRadians ();
            var centralAngle = Math.Acos ((Math.Sin (fromLatitude) * Math.Sin (toLatitude)) +
                (Math.Cos (fromLatitude) * Math.Cos (toLatitude) * Math.Cos (theta)));
            var result = centralAngle * R;
            return result;
        }

        public BoundingRectangle GetBoundingRectangle (double distance, Location location) {
            if (location == null)
                throw new ArgumentNullException (nameof (location));

            if (distance <= 0)
                throw new Exception ("Distance should be positive");

            var radDist = distance / R;

            var latitude = location.Latitude.ToRadians ();
            var minLat = latitude - radDist;
            var maxLat = latitude + radDist;

            double minLon, maxLon;
            if (minLat > MIN_LAT && maxLat < MAX_LAT) {
                var deltaLon = Math.Asin (Math.Sin (radDist) / Math.Cos (latitude));
                var longitude = location.Longitude.ToRadians ();
                minLon = longitude - deltaLon;
                maxLon = longitude + deltaLon;
                if (minLon < MIN_LON) {
                    minLon += 2d * Math.PI;
                }
                if (maxLon > MAX_LON) {
                    maxLon -= 2d * Math.PI;
                }
            } else {
                // a pole is within the distance
                minLat = Math.Max (minLat, MIN_LAT);
                maxLat = Math.Min (maxLat, MAX_LAT);
                minLon = MIN_LON;
                maxLon = MAX_LON;
            }
            return new BoundingRectangle (new Location (minLat, minLon), new Location (maxLat, maxLon));
        }
    }

    public static class DistanceCalculatorExtensions {
        public static double ToRadians (this double value) => value * Math.PI / 180;
    }
}