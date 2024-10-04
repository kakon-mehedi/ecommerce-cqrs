using System;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Queries;
using DarazClone.Students.Services;

namespace DarazClone.Students.QueryHandlers;

public class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, ApiResponseModel>
{
    private readonly IStudentService _service;
    public GetAllStudentsQueryHandler(IStudentService studentService)
    {
        _service = studentService;
    }

    public Task<ApiResponseModel> HandleAsync(GetAllStudentsQuery? query)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponseModel> HandleAsync()
    {
       return await _service.GetAllStudents();
    }
}
