using System;
using MongoDB.Bson.Serialization.Attributes;

namespace DarazClone.Students.Services.ResponseModels;

public class GetAllStudentWithProjectionResponseModel
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Department { get; set; } = string.Empty;
    [BsonId]
    public string ItemId { get; set; } = string.Empty;

}
