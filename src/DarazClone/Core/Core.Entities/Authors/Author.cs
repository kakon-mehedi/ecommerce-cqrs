using System;
using MongoDB.Bson;

namespace DarazClone.Core.Entities.Authors;

public class Author
{
    ObjectId Id { get; set; } = ObjectId.Empty;
    public string Name { get; set; } = string.Empty;

    public int BirthYear { get; set; } = 0;

}
