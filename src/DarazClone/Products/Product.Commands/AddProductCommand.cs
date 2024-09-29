using System;

namespace DarazClone.Products.Commands;
using DarazClone.Core.Shared.Enums.Products;

public class AddProductCommand
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public string Category { get; set; } = string.Empty;
    public ProductTypeEnums Type { get; set; }
}
