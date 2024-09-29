using System;
using System.Windows.Input;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Core.Services.Validators;
using DarazClone.Products.Commands;

namespace DarazClone.Products.Services.Validators;

public class AddProductCommandValidator : IValidator<AddProductCommand>
{
    public ApiResponseModel Validate(AddProductCommand model)
    {
        var response = new ApiResponseModel();

        // if (string.IsNullOrWhiteSpace(model.Title)) response.SetError(0, "Title can not be empty");
        // if (string.IsNullOrWhiteSpace(model.Description)) response.SetError(0, "Description can not be empty");
        // if (string.IsNullOrWhiteSpace(model.OwnerName)) response.SetError(0, "OwnerName can not be empty");
        // if (model.IsCompleted) response.SetError(0, "Completed can not be true initially");

        return response;
    }

    public async Task<ApiResponseModel> ValidateAsync(AddProductCommand model)
    {
        return await Task.Run(() => Validate(model));
    }
}
