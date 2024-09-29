using System;
using System.Net.Sockets;

namespace DarazClone.Core.Services.Dispatchers.Implementations;

public class CommandDispatcher: ICommandDispatcher
{
     private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider) 
    {
        _serviceProvider = serviceProvider;
    }

    public Task<TResponse> Dispatch<TCommand, TResponse>(TCommand command) 
    {
       return DispatchAsync<TCommand, TResponse>(command);
    }
    public Task<TResponse> DispatchAsync<TCommand, TResponse>(TCommand command)
    {
        // Need to Typecast by as, bcz GetService returns an object and it is not typecast correctly 
        var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResponse>)) as ICommandHandler<TCommand, TResponse>;

        if (handler == null)
        {
            var commandTypeDetails = typeof(TCommand);
            var commandResTypeDetails = typeof(TResponse);
            
            throw new InvalidOperationException($"Command handler for {typeof(TCommand).Name} not found.");
        }

        return handler.HandleAsync(command);
    }
}
