using System;
using DarazClone.Core.Entities.Product;
using DarazClone.Core.Services.Injectors;
using DarazClone.Core.Services.Repositories;
using DarazClone.Core.Services.Shared.Models;
using DarazClone.Core.Shared.Enums.Products;
using DarazClone.Products.Commands;
using DarazClone.Products.Services;
using DarazClone.Products.Services.Mappings;

namespace Products.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IRepository _repositoryService;
    private readonly ICommonValueInjectorService _commonValueInjectorService;

    private readonly IMetadataInjectorService _metadataInjectorService;
    public ProductService(IRepository repository, ICommonValueInjectorService commonValueInjectorService, IMetadataInjectorService metadataInjectorService)
    {
        _repositoryService = repository;
        _commonValueInjectorService = commonValueInjectorService;
        _metadataInjectorService = metadataInjectorService;
    }

    public async Task<ApiResponseModel> AddProduct(AddProductCommand command)
    {
        var response = new ApiResponseModel();
        dynamic product = null;


        if (command.Type == ProductTypeEnums.Books)
        {
            product = command.MapToBookProductEntity();
            _commonValueInjectorService.Inject<BookProduct>(product);
            _metadataInjectorService.Inject<BookProduct>(product);
        }

        if (command.Type == ProductTypeEnums.Clothing)
        {
            product = command.MapToClothingProductEntity();
            _commonValueInjectorService.Inject<ClothingProduct>(product);
            _metadataInjectorService.Inject<BookProduct>(product);
        }

        if (command.Type == ProductTypeEnums.Electronics)
        {
            product = command.MapToElectronicsProductEntity();
            _commonValueInjectorService.Inject<ElectronicsProduct>(product);
            _metadataInjectorService.Inject<BookProduct>(product);
        }

        try
        {
            await _repositoryService.InsertAsync<Product>(product);
        }
        catch (Exception e)
        {
            throw;

        }

        return response.SetSuccess(product);



    }

    public Task<ApiResponseModel> GetAllProducts()
    {
        throw new NotImplementedException();
    }
}
