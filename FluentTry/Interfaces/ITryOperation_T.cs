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
        ITryOperation<T> SwallowUnhandled();
        ITryOperation<T> Swallow<TException>() where TException : Exception;

        ITryOperation<T> Log(Action<Exception> handler);
        ITryOperation<T> Log<TException>(Action<TException> handler) where TException : Exception;

        ITryOperation<T> Log(Func<Exception, Task> handler);
        ITryOperation<T> Log<TException>(Func<TException, Task> handler) where TException : Exception;

        ITryOperation<T> Catch(Action handler);
        ITryOperation<T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperation<T> Catch<TException>(Action<TException> handler) where TException : Exception;

        ITryOperation<T> Catch(Func<Task> handler);
        ITryOperation<T> Catch<TException>(Func<Task> handler) where TException : Exception;
        ITryOperation<T> Catch<TException>(Func<TException, Task> handler) where TException : Exception;

        ITryOperation<T> Catch(Func<T> handler);
        ITryOperation<T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperation<T> Catch<TException>(Func<TException, T> handler) where TException : Exception;

        ITryOperation<T> Catch(Func<Task<T>> handler);
        ITryOperation<T> Catch<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryOperation<T> Catch<TException>(Func<TException, Task<T>> handler) where TException : Exception;
    }

    public interface IHandleableTryOperationWithContext<TContext, T> : IFinalizableTryOperationWithContext<TContext, T>
        where TContext : class
    {
        ITryOperationWithContext<TContext, T> Swallow();
        ITryOperationWithContext<TContext, T> SwallowUnhandled();
        ITryOperationWithContext<TContext, T> Swallow<TException>() where TException : Exception;

        ITryOperationWithContext<TContext, T> Log(Action<Exception> handler);
        ITryOperationWithContext<TContext, T> Log(Action<Exception, TContext> handler);
        ITryOperationWithContext<TContext, T> Log<TException>(Action<TException> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Log<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryOperationWithContext<TContext, T> Log(Func<Exception, Task> handler);
        ITryOperationWithContext<TContext, T> Log(Func<Exception, TContext, Task> handler);
        ITryOperationWithContext<TContext, T> Log<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Log<TException>(Func<TException, TContext, Task> handler) where TException : Exception;


        ITryOperationWithContext<TContext, T> Catch(Action handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch(Action<TContext> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryOperationWithContext<TContext, T> Catch(Func<Task> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<Task> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch(Func<TContext, Task> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, TContext, Task> handler) where TException : Exception;

        ITryOperationWithContext<TContext, T> Catch(Func<T> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch(Func<TContext, T> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception;

        ITryOperationWithContext<TContext, T> Catch(Func<Task<T>> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, Task<T>> handler) where TException : Exception;
        ITryOperationWithContext<TContext, T> Catch(Func<TContext, Task<T>> handler);
        ITryOperationWithContext<TContext, T> Catch<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception;
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
