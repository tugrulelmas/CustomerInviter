namespace CustomerInviter.Entities
{
    public class CustomerLocation
    {
        public CustomerLocation(Customer customer, Location location) {
            Customer = customer;
            Location = location;
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public Customer Customer { get; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; }
    }
}