using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public interface ITryBuilder
    {
        ITryOperation<object> Do(Action operation);
        ITryOperation<object, T> Do<T>(Func<T> operation);
        ITryAsyncOperation<object> DoAsync(Func<Task> operation);
        ITryAsyncOperation<object, T> DoAsync<T>(Func<Task<T>> operation);
        ITryBuilder WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate);
        ITryBuilder<TContext> WithContext<TContext>(TContext context) where TContext : class;
    }
}