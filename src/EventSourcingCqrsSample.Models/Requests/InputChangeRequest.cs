namespace EventSourcingCqrsSample.Models.Requests
{
    /// <summary>
    /// This represents the request entity for input change. This must be inherited.
    /// </summary>
    public abstract class InputChangeRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the element Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the element name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the element value.
        /// </summary>
        public string Value { get; set; }
    }
}