using EventSourcingCqrsSample.Models.Responses.Data;

namespace EventSourcingCqrsSample.Models.Responses
{
    /// <summary>
    /// This represents the response entity for the username changed event.
    /// </summary>
    public class UsernameChangeResponse : BaseResponse<UsernameResponseData>
    {
    }
}