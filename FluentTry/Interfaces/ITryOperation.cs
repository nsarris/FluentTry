using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FluentTry
{
    public interface IExecutableOperation
    {
        void Execute();
        ITryResult ExecuteSafe();
        Task ExecuteAsync();

        Task<ITryResult> ExecuteSafeAsync();
    }

    public interface IFinalizableTryOperation
    {
        IFinalizedTryOperation Finally(Action handler);
        IFinalizedTryOperation FinallyAsync(Func<Task> handler);
    }

    public interface IFinalizableTryOperationWithContext<TContext> : IFinalizableTryOperation
        where TContext : class
    {
        IFinalizedTryOperation Finally(Action<TContext> handler);
        IFinalizedTryOperation FinallyAsync(Func<TContext, Task> handler);
    }

    public interface IHandleableTryOperation : IFinalizableTryOperation
    {
        ITryOperation Swallow();
        ITryOperation Swallow<TException>() where TException : Exception;

        ITryOperation Catch(Action handler);
        ITryOperation Catch<TException>(Action handler) where TException : Exception;
        ITryOperation Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperation CatchAsync(Func<Task> handler);
        ITryOperation CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryOperation CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
    }

    public interface IHandleableTryOperationWithContext<TContext> : IFinalizableTryOperationWithContext<TContext>
        where TContext : class
    {
        ITryOperationWithContext<TContext> Swallow();
        ITryOperationWithContext<TContext> Swallow<TException>() where TException : Exception;

        ITryOperationWithContext<TContext> Catch(Action handler);
        ITryOperationWithContext<TContext> Catch<TException>(Action handler) where TException : Exception;
        ITryOperationWithContext<TContext> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperationWithContext<TContext> Catch(Action<TContext> handler);
        ITryOperationWithContext<TContext> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryOperationWithContext<TContext> CatchAsync(Func<Task> handler);
        ITryOperationWithContext<TContext> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryOperationWithContext<TContext> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryOperationWithContext<TContext> CatchAsync(Func<TContext, Task> handler);
        ITryOperationWithContext<TContext> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception;
    }

    public interface ITryOperation : IExecutableOperation, IHandleableTryOperation
    {

    }

    public interface ITryOperationWithContext<TContext> : IExecutableOperation, IHandleableTryOperationWithContext<TContext>
        where TContext : class
    {

    }

    public interface IFinalizedTryOperation : IExecutableOperation
    {

    }
}
