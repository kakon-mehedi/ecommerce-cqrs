using System;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Core.Services.Validators;
using DarazClone.Students.Commands;

namespace DarazClone.Students.Services.Validators.CommandValidators;

public class CreateStudentCommandValidator : IValidator<CreateStudentCommand>
{
    public ApiResponseModel Validate(CreateStudentCommand model)
    {
        var response = new ApiResponseModel();

        if (string.IsNullOrEmpty(model.Name)) response.SetError(0, "Student name can to be empty");
        if (model.Age <= 0) response.SetError(1, "Age can not be zero or negative");

        return response;
    }

    public Task<ApiResponseModel> ValidateAsync(CreateStudentCommand model)
    {
        return Task.Run(() => Validate(model));
    }
}
