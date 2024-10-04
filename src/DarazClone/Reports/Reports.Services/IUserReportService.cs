using System;
using DarazClone.Core.Services.Shared.Models;

namespace Reports.Services;

public interface IUserReportService
{
    Task<ApiResponseModel> GetListOfActiveUsers(); 

    Task<ApiResponseModel> GetNumberOfTotalActiveUsers();
}
