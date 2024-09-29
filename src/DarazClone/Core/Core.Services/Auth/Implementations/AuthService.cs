using System;
using System.Net.Security;
using DarazClone.Core.Services.Constants;

namespace DarazClone.Core.Services.Auth.Implementations;

public class AuthService : IAuthService
{
    public string[] GetAllowedRolesToWrite()
    {
        var roles = new [] {AppRoles.ADMIN};
        return roles;
    }

    public IAuthData GetCurrentUserData()
    {
       var userData = new AuthData();

       return userData;
    }
}
