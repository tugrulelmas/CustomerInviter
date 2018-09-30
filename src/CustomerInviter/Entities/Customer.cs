namespace CustomerInviter.Entities {
    public class Customer {
        public Customer (int id, string name) {
            if (id <= 0)
                throw Exceptions.CustomerIdCannotBeNegative;

            if (string.IsNullOrWhiteSpace(name))
                throw Exceptions.CustomerNameCannotBeEmpty;

            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }
    }
}