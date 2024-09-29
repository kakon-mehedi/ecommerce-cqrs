using System;

namespace DarazClone.Core.Entities;

public abstract class ReadWriteAccessMetadata
{
    public string[] RolesAllowedToRead { get; set; } = Array.Empty<string>();

    public string[] IdsAllowedToRead { get; set; } = Array.Empty<string>();

    public string[] RolesAllowedToWrite { get; set; } = Array.Empty<string>();

    public string[] IdsAllowedToWrite { get; set; } = Array.Empty<string>();

    public string[] RolesAllowedToUpdate { get; set; } = Array.Empty<string>();

    public string[] IdsAllowedToUpdate { get; set; } = Array.Empty<string>();

    public string[] RolesAllowedToDelete { get; set; } = Array.Empty<string>();

    public string[] IdsAllowedToDelete { get; set; } = Array.Empty<string>();
}
