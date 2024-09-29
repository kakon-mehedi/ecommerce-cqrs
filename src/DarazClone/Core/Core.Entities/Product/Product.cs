using System;
using MongoDB.Bson;

namespace DarazClone.Core.Entities.Product;

public class Product : EntityBase
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public string Category { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}

public class ElectronicsProduct : Product
{
    public string ScreenSize { get; set; } = string.Empty;
    public string BatteryCapacity { get; set; } = string.Empty;
}

public class ClothingProduct : Product
{
    public string Size { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
}

public class BookProduct : Product
{
    public string Author { get; set; } = string.Empty;
    public int PageCount { get; set; } = 0;
}
