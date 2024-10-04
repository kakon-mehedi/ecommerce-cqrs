using System;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Queries;
using DarazClone.Students.Services;

namespace DarazClone.Students.QueryHandlers;

public class GetStudentDetailsQueryHandler : IQueryHandler<GetStudentDetailsQuery, ApiResponseModel>
{
    private readonly IStudentService _service;

    public GetStudentDetailsQueryHandler(IStudentService studentService)
    {
        _service = studentService;
    }
    public async Task<ApiResponseModel> HandleAsync(GetStudentDetailsQuery query)
    {
        return await _service.GetStudentByIdAsync(query.ItemId);
    }

    public Task<ApiResponseModel> HandleAsync()
    {
        throw new NotImplementedException();
    }
}
