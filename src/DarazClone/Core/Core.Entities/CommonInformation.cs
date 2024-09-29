using System;

namespace DarazClone.Core.Entities;

public abstract class CommonInformation: CommonSecurityMetadata
{
    public virtual string CreatedBy { get; set; } = string.Empty;

    public virtual DateTime CreateDate { get; set; } = DateTime.Now;

    public string ItemId { get; set; } = string.Empty;

    public virtual string Language { get; set; } = string.Empty;

    public virtual DateTime LastUpdateDate { get; set; }

    public virtual string LastUpdatedBy { get; set; } = string.Empty;

    public string[] Tags { get; set; } = Array.Empty<string>();
    
    public bool IsMarkedToDelete { get; set; }
}
