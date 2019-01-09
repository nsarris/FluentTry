using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public interface ITryBuilder<TContext>
        where TContext : class
    {
        ITryOperation<TContext> Do(Action<TContext> operation);
        ITryOperation<TContext, T> Do<T>(Func<TContext, T> operation);
        ITryAsyncOperation<TContext> DoAsync(Func<TContext, Task> operation);
        ITryAsyncOperation<TContext, T> DoAsync<T>(Func<TContext, Task<T>> operation);
        ITryBuilder<TContext> WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate);
    }
}