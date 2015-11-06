namespace EventSourcingCqrsSample.Models.Responses.Data
{
    /// <summary>
    /// This represents the response data entity for username.
    /// </summary>
    public class UsernameResponseData : BaseResponseData
    {
        /// <summary>
        /// Gets or sets the salutation value.
        /// </summary>
        public string Value { get; set; }
    }
}