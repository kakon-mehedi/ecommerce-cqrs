using System;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Queries;
using DarazClone.Students.Services;

namespace DarazClone.Students.QueryHandlers;

public class GetStudentDetailsWithProjectionQueryHandler : IQueryHandler<GetStudentDetailsWithProjectionQuery, ApiResponseModel>
{
    private readonly IStudentService _service;

    public GetStudentDetailsWithProjectionQueryHandler(IStudentService studentService)
    {
        _service = studentService;
    }
    public async Task<ApiResponseModel> HandleAsync(GetStudentDetailsWithProjectionQuery query)
    {
        return await _service.GetStudentByIdAsyncWithProjection(query.ItemId);
    }

    public Task<ApiResponseModel> HandleAsync()
    {
        throw new NotImplementedException();
    }
}
