using System;
using System.Windows.Input;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Core.Services.Validators;
using DarazClone.Products.Commands;
using DarazClone.Core.Shared.Enums.Products;
using DarazClone.Core.Entities.Product;

namespace DarazClone.Products.Services.Validators;

public class AddProductCommandValidator : IValidator<AddProductCommand>
{
    public ApiResponseModel Validate(AddProductCommand model)
    {
        var response = new ApiResponseModel();

        if (string.IsNullOrWhiteSpace(model.Name)) response.SetError(0, "Name can not be empty");

        if (decimal.Zero == model.Price) response.SetError(0, "Price can not be 0 or null");
        if (string.IsNullOrWhiteSpace(model.Category)) response.SetError(0, "Category can not be empty");

        if (model.Type == ProductTypeEnums.Default) response.SetError(0, "Product type can not be missing");

        if (model.Type == ProductTypeEnums.Books)
        {
            if (string.IsNullOrWhiteSpace(model.Author)) response.SetError(0, "Author Name can not be empty");
            if (model.PageCount == 0) response.SetError(0, "Page count can not be 0");
        }

        if (model.Type == ProductTypeEnums.Clothing)
        {
            if (string.IsNullOrWhiteSpace(model.Size)) response.SetError(0, "Size can not be empty");

            if (string.IsNullOrWhiteSpace(model.Material)) response.SetError(0, "Material can not be empty");
        }

        if (model.Type == ProductTypeEnums.Electronics)
        {
            if (string.IsNullOrWhiteSpace(model.ScreenSize)) response.SetError(0, "Screen size can not be empty");

            if (string.IsNullOrWhiteSpace(model.BatteryCapacity)) response.SetError(0, "Battery capacity can not be empty");
        }

        return response;
    }

    public async Task<ApiResponseModel> ValidateAsync(AddProductCommand model)
    {
        return await Task.Run(() => Validate(model));
    }

}
