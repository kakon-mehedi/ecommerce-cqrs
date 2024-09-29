using System;
using MongoDB.Bson;

namespace DarazClone.Core.Services.Auth.Implementations;

public class AuthData : IAuthData
{
    public string UserName { get; set; } = "kakon11";
    public string UserEmail { get; set; } = "meetkakon@gmail.com";
    public string UserId { get;} = ObjectId.GenerateNewId().ToString();

    public string UserDetailedInfo {
        get { 
            
            string info = $"Username: {UserName} ~ Email: {UserEmail} ~ UserId: {UserId}";

            return info;
            
        }
    }
}
