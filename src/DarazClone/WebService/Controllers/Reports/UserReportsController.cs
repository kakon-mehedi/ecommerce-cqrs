using DarazClone.Core.Services.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Reports.Services;

namespace DarazClone.WebService.Controllers.Reports;

[Route("api/[controller]")]
[ApiController]
public class UserReportsController : ControllerBase
{
    private readonly IUserReportService _userReportService;
    public UserReportsController(IUserReportService userReportService)
    {
        _userReportService = userReportService;
    }

    [HttpGet]
    public async Task< ApiResponseModel> GenerateUserReport()
    {
        var response = new ApiResponseModel();

        var res =  await _userReportService.GetUserReports();

        return response;
    }
}

