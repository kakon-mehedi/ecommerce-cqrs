using System;
using DarazClone.Core.Services.Shared.Models;

namespace Reports.Services;

public interface IUserReportService
{
    Task<ApiResponseModel> GetListOfActiveUsers(); 
    Task<ApiResponseModel> GetUsersGroupByGenderWithProjection();
    Task<ApiResponseModel> GetTotalActiveFemaleUsers();
    Task<ApiResponseModel> GetTotalActiveUsersCount();
}
