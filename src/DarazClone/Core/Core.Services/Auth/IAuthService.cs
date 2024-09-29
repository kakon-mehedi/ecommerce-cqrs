using System;

namespace DarazClone.Core.Services.Auth;

public interface IAuthService
{
    IAuthData GetCurrentUserData();

    string[] GetAllowedRolesToWrite();
}
