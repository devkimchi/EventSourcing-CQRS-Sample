namespace EventSourcingCqrsSample.Models.Responses.Data
{
    /// <summary>
    /// This represents the response data entity for salutation.
    /// </summary>
    public class SalutationResponseData : BaseResponseData
    {
        /// <summary>
        /// Gets or sets the salutation value.
        /// </summary>
        public string Value { get; set; }
    }
}