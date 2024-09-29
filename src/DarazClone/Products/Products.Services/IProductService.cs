using System;
using DarazClone.Core.Entities.Product;
using DarazClone.Core.Services.Shared.Models;

namespace DarazClone.Products.Services;

public interface IProductService
{
    Task<ApiResponseModel> AddProduct(Product product);
    Task<ApiResponseModel> GetAllProducts();
}
