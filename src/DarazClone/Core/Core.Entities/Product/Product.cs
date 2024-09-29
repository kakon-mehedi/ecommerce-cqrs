using System;
using MongoDB.Bson;

namespace DarazClone.Core.Entities.Product;

public class Product : EntityBase
{
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
}

public class ElectronicsProduct : Product
{
    public string ScreenSize { get; set; }
    public string BatteryCapacity { get; set; }
}

public class ClothingProduct : Product
{
    public string Size { get; set; }
    public string Material { get; set; }
}

public class BookProduct : Product
{
    public string Author { get; set; }
    public int PageCount { get; set; }
}
