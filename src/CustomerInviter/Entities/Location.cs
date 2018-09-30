namespace CustomerInviter.Entities {
    public class Location {
        public Location (double latitude, double longitude) {
            if (latitude < -90)
                throw Exceptions.LatitudeCannotBeLessThan90;

            if (latitude > 90)
                throw Exceptions.LatitudeCannotBeGreaterThan90;

            if (longitude < -180)
                throw Exceptions.LongitudeCannotBeLessThan180;

            if (longitude > 180)
                throw Exceptions.LongitudeCannotBeGreaterThan180;

            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; }
    }
}