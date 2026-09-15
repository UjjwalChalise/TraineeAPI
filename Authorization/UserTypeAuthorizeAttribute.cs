using Microsoft.AspNetCore.Authorization;

namespace TraineeAPI.Authorization;

public class UserTypeAuthorizeAttribute : AuthorizeAttribute
{
    public UserTypeAuthorizeAttribute(string userType)
    {
        Policy = userType;
    }
}