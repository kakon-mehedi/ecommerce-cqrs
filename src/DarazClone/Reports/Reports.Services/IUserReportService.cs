using System;
using DarazClone.Core.Services.Shared.Models;

namespace Reports.Services;

public interface IUserReportService
{
    Task<ApiResponseModel> GetUserReports(); 
}
