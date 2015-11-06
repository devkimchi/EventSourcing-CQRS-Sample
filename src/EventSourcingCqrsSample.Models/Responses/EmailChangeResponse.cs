using EventSourcingCqrsSample.Models.Responses.Data;

namespace EventSourcingCqrsSample.Models.Responses
{
    /// <summary>
    /// This represents the response entity for the email changed event.
    /// </summary>
    public class EmailChangeResponse : BaseResponse<EmailResponseData>
    {
    }
}