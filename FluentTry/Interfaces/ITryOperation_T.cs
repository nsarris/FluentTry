using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentTry
{
    public interface IExecutableOperation<T>
    {
        T Execute();
        ITryResult<T> ExecuteSafe();
        Task<T> ExecuteAsync();
        Task<ITryResult<T>> ExecuteSafeAsync();
    }

    public interface IFinalizableTryOperation<T>
    {
        IFinalizedTryOperation<T> Finally(Action handler);
        IFinalizedTryOperation<T> FinallyAsync(Func<Task> handler);
    }

    public interface IFinalizableTryOperationWithContext<TContext, T> : IFinalizableTryOperation<T>
        where TContext : class
    {
        IFinalizedTryOperation<T> Finally(Action<TContext> handler);
        IFinalizedTryOperation<T> FinallyAsync(Func<TContext, Task> handler);
    }

    public interface IHandleableTryOperation<T> : IFinalizableTryOperation<T>
    {
        ITryOperation<T> Swallow();
        ITryOperation<T> Swallow<TException>() where TException : Exception;

        ITryOperation<T> Catch(Action handler);
        ITryOperation<T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperation<T> Catch<TException>(Action<TException> handler) where TException : Exception;

        ITryOperation<T> CatchAsync(Func<Task> handler);
        ITryOperation<T> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryOperation<T> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;

        ITryOperation<T> Catch(Func<T> handler);
        ITryOperation<T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperation<T> Catch<TException>(Func<TException, T> handler) where TException : Exception;

        ITryOperation<T> CatchAsync(Func<Task<T>> handler);
        ITryOperation<T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryOperation<T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception;
    }

    public interface IHandleableTryOperationWithContext<TContext, T> : IFinalizableTryOperationWithContext<TContext, T>
        where TContext : class
    {
        ITryOperationWithContext<TContext, T> Swallow();
        ITryOperationWithContext<TContext, T> Swallow<TException>() where TException : Exception;

        ITryOperationWithContext<TContext, T> Catch(Action handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch(Action<TContext> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryOperationWithContext<TContext, T> CatchAsync(Func<Task> handler);
        ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> CatchAsync(Func<TContext, Task> handler);
        ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception;

        ITryOperationWithContext<TContext, T> Catch(Func<T> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch(Func<TContext, T> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception;

        ITryOperationWithContext<TContext, T> CatchAsync(Func<Task<T>> handler);
        ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> CatchAsync(Func<TContext, Task<T>> handler);
        ITryOperationWithContext<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception;
    }

    public interface ITryOperation<T> : IExecutableOperation<T>, IHandleableTryOperation<T>
    {

    }

    public interface ITryOperationWithContext<TContext, T> : IExecutableOperation<T>, IHandleableTryOperationWithContext<TContext, T>
        where TContext : class
    {

    }

    public interface IFinalizedTryOperation<T> : IExecutableOperation<T>
    {

    }
}
