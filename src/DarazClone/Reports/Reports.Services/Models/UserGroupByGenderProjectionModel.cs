using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Reports.Services.Models;

public class UserGroupByGenderProjectionModel
{
    [BsonId]
    public string KakonId { get; set; } = string.Empty;
    public List<ProjectionData> DataMehedi { get; set; } = new List<ProjectionData>();
}

public class ProjectionData
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public dynamic Comapany { get; set; }

}
