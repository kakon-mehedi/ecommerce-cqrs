namespace DarazClone.Core.Services.Dispatchers;

public interface IQueryDispatcher
{
    Task<TResponse> DispatchAsync<TQuery, TResponse>(TQuery? query);
    Task<TResponse> DispatchAsync<TQuery, TResponse>();
}
