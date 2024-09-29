namespace DarazClone.Core.Services.Dispatchers;

public interface ICommandDispatcher
{
    Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command);

    Task<TResponse> DispatchAsync<TCommand, TResponse>(TCommand command);
}
