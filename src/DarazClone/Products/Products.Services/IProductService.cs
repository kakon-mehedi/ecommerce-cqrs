using System;
using DarazClone.Core.Entities.Product;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Products.Commands;

namespace DarazClone.Products.Services;

public interface IProductService
{
    Task<ApiResponseModel> AddProduct(AddProductCommand command);
    Task<ApiResponseModel> GetAllProducts();
}
