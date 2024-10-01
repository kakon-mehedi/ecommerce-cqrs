using System;
using MongoDB.Bson;

namespace DarazClone.Core.Entities.BooksUser;

public class BookUser
{
    public ObjectId Id { get; set; } = ObjectId.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = false;
    public DateTime Registered { get; set; } = DateTime.Now;
    public int Age { get; set; } = 0;
    public string Gender { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string FavoriteFruit { get; set; } = string.Empty;
    public CompanyInfo Company { get; set; } = new CompanyInfo();
    public List<string> Tags { get; set; } = new List<string>();
}

public class CompanyInfo
{
    public string Title { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public LocationInfo Location { get; set; } = new LocationInfo();
}

public class LocationInfo
{
    public string Country { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
