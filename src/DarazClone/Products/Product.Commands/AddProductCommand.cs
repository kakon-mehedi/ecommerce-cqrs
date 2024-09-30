using System;

namespace DarazClone.Products.Commands;
using DarazClone.Core.Shared.Enums.Products;

public class AddProductCommand
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public string Category { get; set; } = string.Empty;
    public ProductTypeEnums Type { get; set; } = ProductTypeEnums.Default;

    // Electronics Product specific data
    public string ScreenSize { get; set; } = string.Empty;
    public string BatteryCapacity { get; set; } = string.Empty;

    // Clothing Product specific data
    public string Size { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;

    // Books Product specific data
    public string Author { get; set; } = string.Empty;
    public int PageCount { get; set; } = 0;
}
