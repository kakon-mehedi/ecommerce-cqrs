using System;
using DarazClone.Core.Entities;
using DarazClone.Core.Services.Auth;
using Microsoft.AspNetCore.Authentication;

namespace DarazClone.Core.Services.Injectors.Implementations;

public class CommonValueInjectorService: ICommonValueInjectorService
{
    private readonly IAuthService _authService;

    public CommonValueInjectorService(IAuthService authService)
    {
        _authService = authService;
    }   

    public TEntity Inject<TEntity>(TEntity model) where TEntity : EntityBase
    {
        var userInfo = _authService.GetCurrentUserData();

        model.CreatedBy = userInfo.UserDetailedInfo;

        return model;
    }

    public List<TEntity> Inject<TEntity>(List<TEntity> entities) where TEntity : EntityBase
    {
        throw new NotImplementedException();
    }

    public TEntity InjectFromExisting<TEntity>(TEntity model, TEntity source) where TEntity : EntityBase
    {
        throw new NotImplementedException();
    }
}
