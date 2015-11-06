namespace EventSourcingCqrsSample.Models.Requests
{
    /// <summary>
    /// This represents the request entity for the user created event.
    /// </summary>
    public class UserCreateRequest : BaseRequest
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
    }
}