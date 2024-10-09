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
        var response = new ApiResponseModel();

        var data = await _userReportService.GetListOfActiveUsers();

        response.SetSuccess(data);

        return response;
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetNumberOfActiveUsers()
    {
        var response = new ApiResponseModel();

        var data = await _userReportService.GetNumberOfTotalActiveUsers();

        response.SetSuccess(data);

        return response;
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetUsersGroupByGenderWithProjections()
    {
        var response = new ApiResponseModel();

        var data = await _userReportService.GetUsersGroupByGenderWithProjection();

        response.SetSuccess(data);

        return response;
    }

}

