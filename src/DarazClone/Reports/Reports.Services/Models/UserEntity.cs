using System;
using MongoDB.Bson;

namespace Reports.Services.Models;

public class User
{
    public ObjectId id { get; set; } // Assuming the Id is a string type based on your input
    public int index { get; set; }
    public string name { get; set; }
    public bool isActive { get; set; }
    public DateTime registered { get; set; }
    public int age { get; set; }
    public string gender { get; set; }
    public string eyeColor { get; set; }
    public string favoriteFruit { get; set; }

    // Nested Company class
    public Company company { get; set; }
    public List<string> tags { get; set; }
}

public class Company
{
    public string title { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public Location location { get; set; }
}

public class Location
{
    public string country { get; set; }
    public string address { get; set; }
}
