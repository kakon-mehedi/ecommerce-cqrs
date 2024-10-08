using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Commands;
using DarazClone.Students.Queries;
using DarazClone.Students.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DarazClone.WebService.Controllers.Students;

[Route("api/[controller]/[action]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;
    public StudentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<ApiResponseModel> CreateStudent([FromBody] CreateStudentCommand command)
    {
        var response = await _commandDispatcher.DispatchAsync<CreateStudentCommand, ApiResponseModel>(command);

        if (!response.IsSuccess)
        {
            HttpContext.Response.StatusCode = response.HttpStatusCode;
        }

        return response;
    }

    [HttpPost]
    public async Task<ApiResponseModel> CreateMultipleStudent([FromBody] CreateMultipleStudentsCommand command)
    {
        return await _commandDispatcher.DispatchAsync<CreateMultipleStudentsCommand, ApiResponseModel>(command);
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetAllStudents()
    {
        var response = await _queryDispatcher.DispatchAsync<GetAllStudentsQuery, ApiResponseModel>();

        if (!response.IsSuccess)
        {
            HttpContext.Response.StatusCode = response.HttpStatusCode;
        }

        return response;
    }

    [HttpGet]
    public async Task<ApiResponseModel> GetAllStudentsWithProjection()
    {

        var response = await _queryDispatcher.DispatchAsync<GetAllStudentsWithProjectionsQuery, ApiResponseModel>();

        return response;
    }


    [HttpGet]
    public async Task<ApiResponseModel> GetStudentDetails([FromQuery] GetStudentDetailsQuery query )
    {
        var response = await _queryDispatcher.DispatchAsync<GetStudentDetailsQuery, ApiResponseModel>(query);

        return response;
    }

    
    [HttpGet]
    public async Task<ApiResponseModel> GetStudentDetailsWithProjection([FromQuery] GetStudentDetailsWithProjectionQuery query)
    {
        var response = await _queryDispatcher.DispatchAsync<GetStudentDetailsWithProjectionQuery, ApiResponseModel>(query);

        return response;
    }
}

