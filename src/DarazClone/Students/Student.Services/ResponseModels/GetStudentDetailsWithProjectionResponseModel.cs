using System;
using MongoDB.Bson.Serialization.Attributes;

namespace DarazClone.Students.Services.ResponseModels;

public class GetStudentDetailsWithProjectionResponseModel
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
    public string Department { get; set; } = string.Empty;
    [BsonId] // If you don't use this attribute MongoDB driver will give error that it can not find any prop for deserialize _id property, Here _id is mapped with ItemId because of BsonId attribute
    public string ItemId { get; set; } = string.Empty;
}
