using System;
using DarazClone.Core.Services.Shared.Models;

namespace DarazClone.Core.Services.Validators;

public interface IValidator<TCommandOrQuery>
{
    ApiResponseModel Validate(TCommandOrQuery model);
    Task<ApiResponseModel> ValidateAsync(TCommandOrQuery model);
}
