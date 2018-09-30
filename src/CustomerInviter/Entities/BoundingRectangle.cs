using CustomerInviter.Implementations;

namespace CustomerInviter.Entities {
    public class BoundingRectangle {
        public BoundingRectangle (Location minLocation, Location maxLocation) {
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