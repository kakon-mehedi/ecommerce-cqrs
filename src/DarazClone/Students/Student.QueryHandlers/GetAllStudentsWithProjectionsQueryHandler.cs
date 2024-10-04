using System;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Queries;
using DarazClone.Students.Services;

namespace DarazClone.Students.QueryHandlers;

public class GetAllStudentsWithProjectionsQueryHandler : IQueryHandler<GetAllStudentsWithProjectionsQuery, ApiResponseModel>
{
    private readonly IStudentService _service;

    public GetAllStudentsWithProjectionsQueryHandler(IStudentService studentService)
    {
        _service = studentService;
    }

    public Task<ApiResponseModel> HandleAsync(GetAllStudentsWithProjectionsQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponseModel> HandleAsync()
    {
        return await _service.GetAllStudentsWithProjection();
    }
}
