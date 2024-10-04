using System;
using MongoDB.Bson.Serialization.Attributes;

namespace DarazClone.Core.Entities;

public abstract class CommonInformation: CommonSecurityMetadata
{
    public virtual string CreatedBy { get; set; } = string.Empty;

    public virtual DateTime CreateDate { get; set; } = DateTime.Now;

    [BsonId] // Mapping _id which will created by mongodb by default to this ItemId property
    public string ItemId { get; set; }

    public virtual string Language { get; set; } = string.Empty;

    public virtual DateTime LastUpdateDate { get; set; }

    public virtual string LastUpdatedBy { get; set; } = string.Empty;

    public string[] Tags { get; set; } = Array.Empty<string>();
    
    public bool IsMarkedToDelete { get; set; }
}
