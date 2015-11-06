using EventSourcingCqrsSample.Models.Responses.Data;

namespace EventSourcingCqrsSample.Models.Responses
{
    /// <summary>
    /// This represents the response entity for the user created event.
    /// </summary>
    public class UserCreateResponse : BaseResponse<UserResponseData>
    {
    }
}