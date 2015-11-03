namespace EventSourcingCqrsSample.WebApp.Models.Requests
{
    /// <summary>
    /// This represents the base request entity.
    /// </summary>
    public abstract class BaseRequest
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