using System;
using DarazClone.Core.Entities;
using DarazClone.Core.Services.Auth;
using DarazClone.Core.Services.Constants;

namespace DarazClone.Core.Services.Injectors.Implementations;

public class MetadataInjectorService : IMetadataInjectorService
{
    private readonly IAuthService _authService;
    public MetadataInjectorService(IAuthService authService)
    {
        _authService = authService;
    }

    public TEntity Inject<TEntity>(TEntity model) where TEntity : EntityBase
    {
        model.RolesAllowedToRead = _authService.GetAllowedRolesToWrite();
        return model;
    }
}
