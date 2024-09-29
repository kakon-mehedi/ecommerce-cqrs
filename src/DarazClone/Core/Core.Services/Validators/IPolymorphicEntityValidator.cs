using System;
using DarazClone.Core.Services.Shared.Models;

namespace DarazClone.Core.Services.Validators;

public interface IPolymorphicEntityValidator
{
    public TEntity Validate<TEntity>(TEntity source) where TEntity : class, new()
    {
        var dest = new TEntity();  // This works because of the 'new()' constraint
        return dest;
    }

}
