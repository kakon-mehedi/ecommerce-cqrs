using System;
using System.Runtime.InteropServices;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Students.Commands;
using DarazClone.Students.Services;
using DarazClone.Students.Services.Validators.CommandValidators;

namespace DarazClone.Students.CommandHandlers;

public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, ApiResponseModel>
{
    private readonly IStudentService _service;
    public CreateStudentCommandHandler(IStudentService studentService)
    {
        _service = studentService;
    }

    public async Task<ApiResponseModel> HandleAsync(CreateStudentCommand command)
    {
        var validator = new CreateStudentCommandValidator();
        var response = await validator.ValidateAsync(command);
        
        if (response.IsSuccess) {
            response = await _service.CreateStudentAsync(command);
        }

        response.SetStatusCode(response.IsSuccess ? 200 : 400);

        return response;
    }
}
