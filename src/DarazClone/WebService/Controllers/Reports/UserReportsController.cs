using DarazClone.Core.Services.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Reports.Services;

namespace DarazClone.WebService.Controllers.Reports;

[Route("api/[controller]/[action]")]
[ApiController]
public class UserReportsController : ControllerBase
{
    private readonly IUserReportService _userReportService;
    public UserReportsController(IUserReportService userReportService)
    {
        _userReportService = userReportService;
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetListOfActiveUsers()
    {
        return await _userReportService.GetListOfActiveUsers();
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetUsersGroupByGenderWithProjections()
    {
        return await _userReportService.GetUsersGroupByGenderWithProjection();
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetTotalActiveFemaleUsers()
    {
        return await _userReportService.GetTotalActiveFemaleUsers();
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetTotalActiveUsersCount()
    {

        return await _userReportService.GetTotalActiveUsersCount();

    }

}

