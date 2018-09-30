using System;
using CustomerInviter.Implementations;

namespace CustomerInviter.Entities {
    public class BoundingRectangle {
        public BoundingRectangle (Location minLocation, Location maxLocation) {
            if (minLocation == null)
                throw new ArgumentNullException (nameof (minLocation));

            if (maxLocation == null)
                throw new ArgumentNullException (nameof (maxLocation));

            this.MinLocation = minLocation;
            this.MaxLocation = maxLocation;
        }

        public Location MinLocation { get; }

        public Location MaxLocation { get; }

        public bool DoesContain (Location location) {
            var latitude = location.Latitude.ToRadians ();
            var longitude = location.Longitude.ToRadians ();
            return latitude <= MaxLocation.Latitude && latitude >= MinLocation.Latitude &&
                longitude <= MaxLocation.Longitude && longitude >= MinLocation.Longitude;
        }
    }
}