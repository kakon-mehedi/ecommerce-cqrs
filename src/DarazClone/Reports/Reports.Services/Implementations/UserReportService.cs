using System;
using DarazClone.Core.Services.Shared.Models;

namespace Reports.Services.Implementations;

public class UserReportService: IUserReportService
{
    public UserReportService()
    {
    }

    Task<ApiResponseModel> IUserReportService.GetUserReports()
    {
        throw new NotImplementedException();
    }
}
