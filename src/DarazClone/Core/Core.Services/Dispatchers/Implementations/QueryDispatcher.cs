using System;
using Microsoft.Extensions.DependencyInjection;

namespace DarazClone.Core.Services.Dispatchers.Implementations;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> DispatchAsync<TQuery, TResponse>(TQuery? query)
    {
        var handler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResponse>)) as IQueryHandler<TQuery, TResponse>;

        if (handler == null)
        {
            throw new InvalidOperationException($"Query handler for {typeof(TQuery).Name} not found.");
        }

        return handler.HandleAsync(query);

    }

    public Task<TResponse> DispatchAsync<TQuery, TResponse>()
    {
        var handler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResponse>)) as IQueryHandler<TQuery, TResponse>;

        var queryName = typeof(TQuery).Name;
        var responseName = typeof(TResponse).Name;

        if (handler == null)
        {
            throw new InvalidOperationException($"Query handler for {typeof(TQuery).Name} not found.");
        }

        return handler.HandleAsync();
    }
}
