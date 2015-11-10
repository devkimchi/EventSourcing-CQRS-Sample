namespace EventSourcingCqrsSample.Models.Responses.Data
{
    /// <summary>
    /// This represents the response data entity for user.
    /// </summary>
    public class UserResponseData : BaseResponseData
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }
    }
}