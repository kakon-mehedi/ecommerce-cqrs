using System;
using DarazClone.Core.Entities.Product;
using MongoDB.Bson;

namespace DarazClone.Products.Services.Mappings;

public static class ProductEntityMapper
{
    public static ElectronicsProduct MapToElectronicsProductEntity(this ElectronicsProduct source) {
        var destination = new ElectronicsProduct();
        
        destination.Id = ObjectId.GenerateNewId();
        destination.Name = source.Name;
        destination.Price = source.Price;
        destination.Category = source.Category;
        destination.Type = source.Type;

        destination.ScreenSize = source.ScreenSize;
        destination.BatteryCapacity = source.BatteryCapacity;


        return destination;
    }

    public static ClothingProduct MapToClothingProductEntity(this ClothingProduct source) {
        var destination = new ClothingProduct();
        
        destination.Id = ObjectId.GenerateNewId();
        destination.Name = source.Name;
        destination.Price = source.Price;
        destination.Category = source.Category;
        destination.Type = source.Type;

        destination.Size = source.Size;
        destination.Material = source.Material;


        return destination;
    }

    public static BookProduct MapToBookProductEntity(this BookProduct source) {
        var destination = new BookProduct();
        
        destination.Id = ObjectId.GenerateNewId();
        destination.Name = source.Name;
        destination.Price = source.Price;
        destination.Category = source.Category;
        destination.Type = source.Type;

        destination.Author = source.Author;
        destination.PageCount = source.PageCount;


        return destination;
    }

}
