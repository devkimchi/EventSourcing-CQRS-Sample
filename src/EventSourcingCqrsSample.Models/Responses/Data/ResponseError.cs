namespace EventSourcingCqrsSample.Models.Responses.Data
{
    /// <summary>
    /// This represents the response error entity.
    /// </summary>
    public class ResponseError
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        public string StackTrace { get; set; }
    }
}