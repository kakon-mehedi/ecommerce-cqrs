using System;
using DarazClone.Core.Entities;

namespace DarazClone.Core.Services.Injectors;

public interface IMetadataInjectorService
{
    TEntity Inject<TEntity>(TEntity model) where TEntity : EntityBase;
}
