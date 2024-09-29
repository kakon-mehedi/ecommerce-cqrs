using System;
using System.ComponentModel.DataAnnotations;
using DarazClone.Core.Services.Dispatchers;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Products.Commands;
using DarazClone.Products.Services;
using DarazClone.Products.Services.Validators;

namespace DarazClone.Products.CommandHandlers;


public class AddProductCommandHandler : ICommandHandler<AddProductCommand, ApiResponseModel>
{
    private readonly IProductService _productService;
    public AddProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<ApiResponseModel> HandleAsync(AddProductCommand command)
    {
        var validator = new AddProductCommandValidator();

        var res = await validator.ValidateAsync(command);

        return res;
        
    }
}
