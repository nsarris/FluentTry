using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentTry
{

    #region ITryOperation / ITryAsyncOperation

    public static class IConfigurableTryOperationExtensions
    {
        public static T WithExceptionHandlerSequenceBehaviour<T>(this T operation, ExceptionHandlerSequenceBehaviour exceptionHandlerSequenceBehaviour)
            where T : IConfigurableTryOperation
        {
            if (operation is IConfigurableTryOperationInternal operationInternal)
                operationInternal.ExceptionHandlerSequenceBehaviour = exceptionHandlerSequenceBehaviour;

            return operation;
        }
    }

    public interface IConfigurableTryOperation
    {

    }

    internal interface IConfigurableTryOperationInternal
    {
        ExceptionHandlerSequenceBehaviour ExceptionHandlerSequenceBehaviour { get; set; }
    }

    public interface IExecutableOperation
    {
        void Execute();
        ITryResult ExecuteSafe();
    }

    public interface IExecutableAsyncOperation
    {
        Task ExecuteAsync();
        Task<ITryResult> ExecuteSafeAsync();
    }

    public interface IFinalizableTryOperationNoContext
    {
        IFinalizedTryOperation Finally(Action handler);
    }

    public interface IFinalizableTryOperation<out TContext> : IFinalizableTryOperationNoContext
        where TContext : class
    {
        IFinalizedTryOperation Finally(Action<TContext> handler);
    }

    public interface IFinalizableTryAsyncOperationNoContext
    {
        IFinalizedTryAsyncOperation Finally(Action handler);
        IFinalizedTryAsyncOperation FinallyAsync(Func<Task> handler);
    }

    public interface IFinalizableTryAsyncOperation<TContext> : IFinalizableTryAsyncOperationNoContext
        where TContext : class
    {
        IFinalizedTryAsyncOperation Finally(Action<TContext> handler);
        IFinalizedTryAsyncOperation FinallyAsync(Func<TContext, Task> handler);
    }

    public interface IHandleableTryOperationNoContext : IFinalizableTryOperationNoContext
    {
        ITryOperationNoContext Swallow();
        ITryOperationNoContext Swallow<TException>() where TException : Exception;

        ITryOperationNoContext Catch(Action handler);
        ITryOperationNoContext Catch<TException>(Action handler) where TException : Exception;
        ITryOperationNoContext Catch<TException>(Action<TException> handler) where TException : Exception;
    }

    public interface IHandleableTryOperation<TContext> : IFinalizableTryOperation<TContext>
        where TContext : class
    {
        ITryOperation<TContext> Swallow();
        ITryOperation<TContext> Swallow<TException>() where TException : Exception;

        ITryOperation<TContext> Catch(Action handler);
        ITryOperation<TContext> Catch<TException>(Action handler) where TException : Exception;
        ITryOperation<TContext> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperation<TContext> Catch(Action<TContext> handler);
        ITryOperation<TContext> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperationNoContext : IFinalizableTryAsyncOperationNoContext
    {
        ITryAsyncOperationNoContext Swallow();
        ITryAsyncOperationNoContext Swallow<TException>() where TException : Exception;

        ITryAsyncOperationNoContext Catch(Action handler);
        ITryAsyncOperationNoContext Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperationNoContext Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryAsyncOperationNoContext CatchAsync(Func<Task> handler);
        ITryAsyncOperationNoContext CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperationNoContext CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperation<TContext> : IFinalizableTryAsyncOperation<TContext>
        where TContext : class
    {
        ITryAsyncOperation<TContext> Swallow();
        ITryAsyncOperation<TContext> Swallow<TException>() where TException : Exception;

        ITryAsyncOperation<TContext> Catch(Action handler);
        ITryAsyncOperation<TContext> Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperation<TContext> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryAsyncOperation<TContext> Catch(Action<TContext> handler);
        ITryAsyncOperation<TContext> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryAsyncOperation<TContext> CatchAsync(Func<Task> handler);
        ITryAsyncOperation<TContext> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext> CatchAsync(Func<TContext, Task> handler);
        ITryAsyncOperation<TContext> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception;
    }


    public interface ITryOperationNoContext : IExecutableOperation, IHandleableTryOperationNoContext, IConfigurableTryOperation
    {

    }

    public interface ITryAsyncOperationNoContext : IExecutableAsyncOperation, IHandleableTryAsyncOperationNoContext, IConfigurableTryOperation
    {

    }

    public interface ITryOperation<TContext> : IExecutableOperation, IHandleableTryOperation<TContext>, IConfigurableTryOperation
        where TContext : class
    {

    }

    public interface ITryAsyncOperation<TContext> : IExecutableAsyncOperation, IHandleableTryAsyncOperation<TContext>, IConfigurableTryOperation
        where TContext : class
    {

    }

    public interface IFinalizedTryOperation : IExecutableOperation, IConfigurableTryOperation
    {

    }

    public interface IFinalizedTryAsyncOperation : IExecutableAsyncOperation, IConfigurableTryOperation
    {

    }

    #endregion

    #region ITryOperation<T> / ITryAsyncOperation<T>

    public interface IExecutableOperation<out T>
    {
        T Execute();
        ITryResult<T> ExecuteSafe();
    }

    public interface IExecutableAsyncOperation<T>
    {
        Task<T> ExecuteAsync();
        Task<ITryResult<T>> ExecuteSafeAsync();
    }

    public interface IFinalizableTryOperationNoContext<out T>
    {
        IFinalizedTryOperation<T> Finally(Action handler);
    }

    public interface IFinalizableTryOperation<out TContext, T> : IFinalizableTryOperationNoContext<T>
        where TContext : class
    {
        IFinalizedTryOperation<T> Finally(Action<TContext> handler);
    }

    public interface IFinalizableTryAsyncOperationNoContext<T>
    {
        IFinalizedTryAsyncOperation<T> Finally(Action handler);
        IFinalizedTryAsyncOperation<T> FinallyAsync(Func<Task> handler);
    }

    public interface IFinalizableTryAsyncOperation<TContext, T> : IFinalizableTryAsyncOperationNoContext<T>
        where TContext : class
    {
        IFinalizedTryAsyncOperation<T> Finally(Action<TContext> handler);
        IFinalizedTryAsyncOperation<T> FinallyAsync(Func<TContext, Task> handler);
    }

    public interface IHandleableTryOperationNoContext<T> : IFinalizableTryOperationNoContext<T>
    {
        ITryOperationNoContext<T> Swallow();
        ITryOperationNoContext<T> Swallow<TException>() where TException : Exception;

        ITryOperationNoContext<T> Catch(Action handler);
        ITryOperationNoContext<T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperationNoContext<T> Catch<TException>(Action<TException> handler) where TException : Exception;

        ITryOperationNoContext<T> Catch(Func<T> handler);
        ITryOperationNoContext<T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperationNoContext<T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
    }

    public interface IHandleableTryOperation<TContext, T> : IFinalizableTryOperation<TContext, T>
        where TContext : class
    {
        ITryOperation<TContext, T> Swallow();
        ITryOperation<TContext, T> Swallow<TException>() where TException : Exception;

        ITryOperation<TContext, T> Catch(Action handler);
        ITryOperation<TContext, T> Catch<TException>(Action handler) where TException : Exception;
        ITryOperation<TContext, T> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryOperation<TContext, T> Catch(Action<TContext> handler);
        ITryOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryOperation<TContext, T> Catch(Func<T> handler);
        ITryOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
        ITryOperation<TContext, T> Catch(Func<TContext, T> handler);
        ITryOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperationNoContext<T> : IFinalizableTryAsyncOperationNoContext<T>
    {
        ITryAsyncOperationNoContext<T> Swallow();
        ITryAsyncOperationNoContext<T> Swallow<TException>() where TException : Exception;

        ITryAsyncOperationNoContext<T> Catch(Action handler);
        ITryAsyncOperationNoContext<T> Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> Catch<TException>(Action<TException> handler) where TException : Exception;

        ITryAsyncOperationNoContext<T> CatchAsync(Func<Task> handler);
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;

        ITryAsyncOperationNoContext<T> Catch(Func<T> handler);
        ITryAsyncOperationNoContext<T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> Catch<TException>(Func<TException, T> handler) where TException : Exception;

        ITryAsyncOperationNoContext<T> CatchAsync(Func<Task<T>> handler);
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryAsyncOperationNoContext<T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception;
    }

    public interface IHandleableTryAsyncOperation<TContext, T> : IFinalizableTryAsyncOperation<TContext, T>
        where TContext : class
    {
        ITryAsyncOperation<TContext, T> Swallow();
        ITryAsyncOperation<TContext, T> Swallow<TException>() where TException : Exception;

        ITryAsyncOperation<TContext, T> Catch(Action handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Action handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch(Action<TContext> handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception;

        ITryAsyncOperation<TContext, T> CatchAsync(Func<Task> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception;

        ITryAsyncOperation<TContext, T> Catch(Func<T> handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> Catch(Func<TContext, T> handler);
        ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception;

        ITryAsyncOperation<TContext, T> CatchAsync(Func<Task<T>> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception;
        ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task<T>> handler);
        ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception;
    }


    public interface ITryOperationNoContext<T> : IExecutableOperation<T>, IHandleableTryOperationNoContext<T>, IConfigurableTryOperation
    {

    }

    public interface ITryOperation<TContext, T> : IExecutableOperation<T>, IHandleableTryOperation<TContext, T>, IConfigurableTryOperation
        where TContext : class
    {

    }

    public interface ITryAsyncOperationNoContext<T> : IExecutableAsyncOperation<T>, IHandleableTryAsyncOperationNoContext<T>, IConfigurableTryOperation
    {

    }

    public interface ITryAsyncOperation<TContext, T> : IExecutableAsyncOperation<T>, IHandleableTryAsyncOperation<TContext, T>, IConfigurableTryOperation
        where TContext : class
    {

    }

    public interface IFinalizedTryOperation<out T> : IExecutableOperation<T>, IConfigurableTryOperation
    {

    }

    public interface IFinalizedTryAsyncOperation<T> : IExecutableAsyncOperation<T>, IConfigurableTryOperation
    {

    }

    #endregion

    #region Exception Handlers

    internal interface IExceptionHandler<TContext, T>
        where TContext : class
    {
        T Execute(TContext context, Exception e);
        Task<T> ExecuteAsync(TContext context, Exception e);
    }

    internal class ExceptionHandler<TException, TContext, T> : IExceptionHandler<TContext, T>
        where TException : Exception
        where TContext : class
    {
        private readonly Delegate executor;

        private ExceptionHandler(Delegate executor) => this.executor = executor;

        public ExceptionHandler(Func<TException, T> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Action<TException> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Action handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<T> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Action<TContext> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<TContext, T> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Action<TException, TContext> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<TException, TContext, T> handler)
            : this(handler as Delegate) { }

        public T Execute(TContext context, TException e)
        {
            switch (executor)
            {
                case Action actionHandler:
                    actionHandler(); return default;
                case Action<TException> actionWithException:
                    actionWithException(e); return default;
                case Func<T> funcHandler:
                    return funcHandler();
                case Func<TException, T> funcWithException:
                    return funcWithException(e);
                case Action<TContext> actionHandlerWithContext:
                    actionHandlerWithContext(context); return default;
                case Action<TException, TContext> actionHandlerWithExceptionAndContext:
                    actionHandlerWithExceptionAndContext(e, context); return default;
                case Func<TContext, T> funcHandlerWithContext:
                    return funcHandlerWithContext(context);
                case Func<TException, TContext, T> funcHandlerWithExceptionAndContext:
                    return funcHandlerWithExceptionAndContext(e, context);
                default:
                    throw new NotSupportedException("Unsupported exception handler delegate type.");
            }
        }

        public T Execute(TContext context, Exception e)
        {
            return Execute(context, (TException)e);
        }

        public Task<T> ExecuteAsync(TContext context, TException e)
        {

            try
            {
                var result = Execute(context, e);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromException<T>(ex);
            }

        }

        public Task<T> ExecuteAsync(TContext context, Exception e)
        {
            return ExecuteAsync(context, (TException)e);
        }
    }

    internal class ExceptionAsyncHandler<TException, TContext, T> : IExceptionHandler<TContext, T>
        where TException : Exception
        where TContext : class
    {
        private readonly Delegate executor;

        private ExceptionAsyncHandler(Delegate executor) => this.executor = executor;

        public ExceptionAsyncHandler(Func<TException, Task<T>> handler)
            : this(handler as Delegate) { }

        public ExceptionAsyncHandler(Func<TException, Task> handler)
            : this(handler as Delegate) { }

        public ExceptionAsyncHandler(Func<Task> handler)
            : this(handler as Delegate) { }

        public ExceptionAsyncHandler(Func<Task<T>> handler)
            : this(handler as Delegate) { }

        public ExceptionAsyncHandler(Func<TException, TContext, Task<T>> handler)
            : this(handler as Delegate) { }

        public ExceptionAsyncHandler(Func<TException, TContext, Task> handler)
            : this(handler as Delegate) { }

        public ExceptionAsyncHandler(Func<TContext, Task> handler)
            : this(handler as Delegate) { }

        public ExceptionAsyncHandler(Func<TContext, Task<T>> handler)
            : this(handler as Delegate) { }

        public Task<T> ExecuteAsync(TContext context, TException e)
        {
            switch (executor)
            {
                case Func<Task<T>> funcHandler:
                    return funcHandler();
                case Func<TException, Task<T>> funcWithException:
                    return funcWithException(e);
                case Func<Task> actionHandler:
                    return actionHandler().ContinueWith(_ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion);
                case Func<TException, Task> actionWithException:
                    return actionWithException(e).ContinueWith(_ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion);

                case Func<TContext, Task<T>> funcHandlerWithContext:
                    return funcHandlerWithContext(context);
                case Func<TException, TContext, Task<T>> funcWithExceptionAndContext:
                    return funcWithExceptionAndContext(e, context);
                case Func<TContext, Task> actionHandlerWithContext:
                    return actionHandlerWithContext(context).ContinueWith(_ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion);
                case Func<TException, TContext, Task> actionWithExceptionAndContext:
                    return actionWithExceptionAndContext(e, context).ContinueWith(_ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion);
                default:
                    throw new NotSupportedException("Unsupported exception handler delegate type.");
            }
        }

        public Task<T> ExecuteAsync(TContext context, Exception e)
        {
            return ExecuteAsync(context, (TException)e);
        }

        public T Execute(TContext context, TException e)
        {
            return AsyncTaskHelper.RunSync(() => ExecuteAsync(context, e));
        }

        public T Execute(TContext context, Exception e)
        {
            return Execute(context, (TException)e);
        }
    }

    public enum ExceptionHandlerSequenceBehaviour
    {
        ThrowIfNotValid,
        AutoOrder,
        IgnoreAndGetFirst
    }

    public class DuplicateExceptionHandlerException : Exception
    {
        public DuplicateExceptionHandlerException() 
            : base($"Exception types with multiple handlers detected.")
        {
        }
    }

    public class InvalidExceptionHandlerSequenceException : Exception
    {
        public InvalidExceptionHandlerSequenceException()
            : base($"The sequence of exception handlers has detected super classes before sub classes.")
        {
        }
    }

    internal class ExceptionHandlers<TContext, T>
        where TContext : class
    {
        private readonly Dictionary<Type, List<IExceptionHandler<TContext, T>>> handlers = new Dictionary<Type, List<IExceptionHandler<TContext, T>>>();
        private IExceptionHandler<TContext, T> finallyHandler = null;

        public IExceptionHandler<TContext, T> GetHandler<TException>()
            where TException : Exception
        {
            return GetHandler(typeof(TException));
        }

        public IExceptionHandler<TContext, T> GetFinallyHandler()
        {
            return finallyHandler;
        }

        public IExceptionHandler<TContext, T> GetHandler(Type exceptionType, ExceptionHandlerSequenceBehaviour exceptionTypeSequenceBehaviour)
        {
            switch(exceptionTypeSequenceBehaviour)
            {
                case ExceptionHandlerSequenceBehaviour.ThrowIfNotValid:
                    if (!AssertNoDuplicates())
                        throw new DuplicateExceptionHandlerException();
                    if (!AssertInheritanceHierarchy())
                        throw new InvalidExceptionHandlerSequenceException();
                    return GetHandler(exceptionType);
                case ExceptionHandlerSequenceBehaviour.AutoOrder:
                    if (!AssertNoDuplicates())
                        throw new DuplicateExceptionHandlerException();
                    return GetSortedHandler(exceptionType);
                case ExceptionHandlerSequenceBehaviour.IgnoreAndGetFirst:
                    return GetHandler(exceptionType);
                default:
                    throw new NotSupportedException("Unsupported ExceptionHandlerSequenceBehaviour value");
            }
        }

        public IExceptionHandler<TContext, T> GetHandler(Type exceptionType)
        {
            return handlers.FirstOrDefault(handler => handler.Key.IsAssignableFrom(exceptionType)).Value.First();
        }

        public IExceptionHandler<TContext, T> GetSortedHandler(Type exceptionType)
        {
            return handlers
                .OrderByDescending(x => x.Key.GetHierarchyDepth())
                .FirstOrDefault(handler => handler.Key.IsAssignableFrom(exceptionType)).Value.First();
        }

        public void AddHandler<TException>(Action<TException> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddHandler<TException>(Action handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddHandler<TException>(Func<TException, T> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddHandler<TException>(Func<T> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddHandler<TException>(Action<TContext> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddHandler<TException>(Action<TException, TContext> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddHandler<TException>(Func<TContext, T> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddHandler<TException>(Func<TException, TContext, T> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TException, Task> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<Task> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TException, Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TContext, Task> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TException, TContext, Task> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TContext, Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<Exception, TContext, Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionAsyncHandler<TException, TContext, T>(handler));
        }

        public void SetFinallyHandler(Action handler)
        {
            finallyHandler = new ExceptionHandler<Exception, TContext, T>(handler);
        }

        public void SetAsyncFinallyHandler(Func<Task> handler)
        {
            finallyHandler = new ExceptionAsyncHandler<Exception, TContext, T>(handler);
        }

        public void SetFinallyHandler(Action<TContext> handler)
        {
            finallyHandler = new ExceptionHandler<Exception, TContext, T>(handler);
        }

        public void SetAsyncFinallyHandler(Func<TContext, Task> handler)
        {
            finallyHandler = new ExceptionAsyncHandler<Exception, TContext, T>(handler);
        }

        public bool AssertNoDuplicates()
        {
            return !handlers.Any(x => x.Value.Count > 1);
        }

        public bool AssertInheritanceHierarchy()
        {
            var depthSequence = handlers.Keys.Select(x => x.GetHierarchyDepth()).ToList();
            var orderedDepthSequence = depthSequence.OrderByDescending(x => x);

            return depthSequence.SequenceEqual(orderedDepthSequence);
        }
    }

    #endregion Exception Handlers

    internal sealed class TryOperation<TContext, T> : ITryOperation<TContext, T>, ITryOperation<TContext>, IFinalizedTryOperation, IFinalizedTryOperation<T>, IConfigurableTryOperationInternal
        where TContext : class
    {
        private readonly ExceptionHandlers<TContext, T> handlers = new ExceptionHandlers<TContext, T>();
        private readonly Func<TContext, T> operation;
        private readonly TContext context;

        ExceptionHandlerSequenceBehaviour IConfigurableTryOperationInternal.ExceptionHandlerSequenceBehaviour { get; set; }

        public TryOperation(Func<TContext, T> operation, TContext context)
        {
            this.operation = operation;
            this.context = context;
        }

        #region ITryOperation<T>

        public ITryOperation<TContext, T> Swallow<TException>()
            where TException : Exception
        {
            handlers.AddHandler<TException>(() => default);
            return this;
        }

        public ITryOperation<TContext, T> Swallow()
        {
            handlers.AddHandler<Exception>(() => default);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Action handler)
            where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Action<TException> handler)
            where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch(Action handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public ITryOperation<TContext, T> Catch(Func<T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch(Action<TContext> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch(Func<TContext, T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }


        public IFinalizedTryOperation<T> Finally(Action handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryOperation<T> Finally(Action<TContext> handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        #endregion ITryOperation<T>

        #region ITryOperation (Void)

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Swallow()
        {
            Swallow();
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch<TException>(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch<TException>(Action<TException> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch(Action<TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryOperation<TContext> IHandleableTryOperation<TContext>.Catch<TException>(Action<TException, TContext> handler)
        {
            Catch(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperation<TContext>.Finally(Action<TContext> handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryOperation IFinalizableTryOperationNoContext.Finally(Action handler)
        {
            Finally(handler);
            return this;
        }

        #endregion ITryOperation

        #region Execute

        void IExecutableOperation.Execute()
        {
            Execute();
        }

        public T Execute()
        {
            try
            {
                return operation(context);
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), ((IConfigurableTryOperationInternal)this).ExceptionHandlerSequenceBehaviour);
                if (handler == null) throw;
                return handler.Execute(context, e);
            }
            finally
            {
                handlers.GetFinallyHandler()?.Execute(context, null);
            }
        }

        ITryResult IExecutableOperation.ExecuteSafe()
        {
            return ExecuteSafe();
        }

        public ITryResult<T> ExecuteSafe()
        {
            try
            {
                return new TryResult<T>(operation(context));
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), ((IConfigurableTryOperationInternal)this).ExceptionHandlerSequenceBehaviour);

                if (handler == null)
                    return new TryResult<T>(e);

                try
                {
                    return new TryResult<T>(handler.Execute(context, e));
                }
                catch (Exception rethrownException)
                {
                    return new TryResult<T>(rethrownException);
                }
            }
            finally
            {
                handlers.GetFinallyHandler()?.Execute(context, null);
            }
        }

        #endregion Execute
    }

    internal sealed class TryAsyncOperation<TContext, T> : ITryAsyncOperation<TContext, T>, ITryAsyncOperation<TContext>, IFinalizedTryAsyncOperation, IFinalizedTryAsyncOperation<T>, IConfigurableTryOperationInternal
        where TContext : class
    {
        private readonly ExceptionHandlers<TContext, T> handlers = new ExceptionHandlers<TContext, T>();
        private readonly Func<TContext, Task<T>> operation;
        private readonly TContext context;

        ExceptionHandlerSequenceBehaviour IConfigurableTryOperationInternal.ExceptionHandlerSequenceBehaviour { get; set; }

        public TryAsyncOperation(Func<TContext, Task<T>> operation, TContext context)
        {
            this.operation = operation;
            this.context = context;
        }

        #region ITryAsyncOperation<T>

        public ITryAsyncOperation<TContext, T> Swallow<TException>()
            where TException : Exception
        {
            handlers.AddHandler<TException>(() => default);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Swallow()
        {
            handlers.AddHandler<Exception>(() => default);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Action handler)
            where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException> handler)
            where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Action handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task> handler)
            where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<Task> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Func<T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Func<T> handler) where TException : Exception
        {
            handlers.AddHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler<TException>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Action<TException, TContext> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Func<TContext, T> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch<TException>(Func<TException, TContext, T> handler) where TException : Exception
        {
            handlers.AddHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync(Func<TContext, Task<T>> handler)
        {
            handlers.AddAsyncHandler<Exception>(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> CatchAsync<TException>(Func<TException, TContext, Task<T>> handler) where TException : Exception
        {
            handlers.AddAsyncHandler(handler);
            return this;
        }

        public ITryAsyncOperation<TContext, T> Catch(Action<TContext> handler)
        {
            handlers.AddHandler<Exception>(handler);
            return this;
        }


        public IFinalizedTryAsyncOperation<T> Finally(Action handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryAsyncOperation<T> FinallyAsync(Func<Task> handler)
        {
            handlers.SetAsyncFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryAsyncOperation<T> Finally(Action<TContext> handler)
        {
            handlers.SetFinallyHandler(handler);
            return this;
        }

        public IFinalizedTryAsyncOperation<T> FinallyAsync(Func<TContext, Task> handler)
        {
            handlers.SetAsyncFinallyHandler(handler);
            return this;
        }


        #endregion ITryOperation<T>

        #region ITryAsyncOperation (Void)

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Swallow()
        {
            Swallow();
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Swallow<TException>()
        {
            Swallow<TException>();
            return this;
        }
        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch<TException>(Action handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch<TException>(Action<TException> handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync<TException>(Func<Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync<TException>(Func<TException, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }


        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch(Action<TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.Catch<TException>(Action<TException, TContext> handler)
        {
            Catch(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync(Func<TContext, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        ITryAsyncOperation<TContext> IHandleableTryAsyncOperation<TContext>.CatchAsync<TException>(Func<TException, TContext, Task> handler)
        {
            CatchAsync(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperation<TContext>.Finally(Action<TContext> handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperation<TContext>.FinallyAsync(Func<TContext, Task> handler)
        {
            FinallyAsync(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperationNoContext.Finally(Action handler)
        {
            Finally(handler);
            return this;
        }

        IFinalizedTryAsyncOperation IFinalizableTryAsyncOperationNoContext.FinallyAsync(Func<Task> handler)
        {
            FinallyAsync(handler);
            return this;
        }

        #endregion ITryOperation

        #region ExecuteAsync

        Task IExecutableAsyncOperation.ExecuteAsync()
        {
            return ExecuteAsync();
        }

        public async Task<T> ExecuteAsync()
        {
            try
            {
                return await operation(context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType(), ((IConfigurableTryOperationInternal)this).ExceptionHandlerSequenceBehaviour);
                if (handler == null) throw;
                try
                {
                    return await handler.ExecuteAsync(context, e).ConfigureAwait(false);
                }
                catch (Exception rethrownException)
                {
                    throw rethrownException;
                }
            }
            finally
            {
                var finallyHandler = handlers.GetFinallyHandler();
                if (finallyHandler != null)
                {
                    await finallyHandler.ExecuteAsync(context, null).ConfigureAwait(false);
                }
            }
        }

        public Task<T> ExecuteAsync2()
        {
            return operation(context)
                .ContinueWith<T, T>((task, context) =>
                 {
                     if (task.IsFaulted)
                     {
                         var handler = handlers.GetHandler(task.Exception.GetType(), ((IConfigurableTryOperationInternal)this).ExceptionHandlerSequenceBehaviour);
                         if (handler == null) throw task.Exception;

                         return handler.ExecuteAsync((TContext)context, task.Exception);
                     }

                     return Task.FromResult(default(T));
                 }, context)
                .ContinueWith<T, T>((task, context) =>
                {
                    var result = task.Status == TaskStatus.RanToCompletion ? task.Result : default;

                    var finallyHandler = handlers.GetFinallyHandler();
                    if (finallyHandler != null)
                    {
                        if (!task.IsFaulted)
                            return finallyHandler.ExecuteAsync((TContext)context, null).ContinueWith(t => result);
                        else
                            return finallyHandler.ExecuteAsync((TContext)context, null).ContinueWith<T, T>(t => Task.FromException<T>(task.Exception.FlattenRecursive().InnerException));
                    }
                    else
                    {
                        if (!task.IsFaulted)
                            return Task.FromResult(result);
                        else
                            return Task.FromException<T>(task.Exception);
                    }

                }, context);
        }

        Task<ITryResult> IExecutableAsyncOperation.ExecuteSafeAsync()
        {
            return ExecuteSafeAsync().ContinueWith(t => t.Result as ITryResult);
        }

        public async Task<ITryResult<T>> ExecuteSafeAsync()
        {
            try
            {
                return new TryResult<T>(await operation(context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                var handler = handlers.GetHandler(e.GetType());

                if (handler == null)
                    return new TryResult<T>(e);

                try
                {
                    return new TryResult<T>(await handler.ExecuteAsync(context, e).ConfigureAwait(false));
                }
                catch (Exception rethrownException)
                {
                    return new TryResult<T>(rethrownException);
                }
            }
            finally
            {
                var finallyHandler = handlers.GetFinallyHandler();
                if (finallyHandler != null)
                    await finallyHandler.ExecuteAsync(context, null).ConfigureAwait(false);
            }
        }





        #endregion Execute
    }


    #region Factory

    public class ContextualTryBuilder<TContext>
        where TContext : class
    {
        private readonly TContext context;

        internal ContextualTryBuilder(TContext context)
        {
            this.context = context;
        }

        public ITryOperation<TContext> Do(Action<TContext> operation)
        {
            return Try.Do(context, operation);
        }

        public ITryOperation<TContext, T> Do<T>(Func<TContext, T> operation)
        {
            return Try.Do(context, operation);
        }

        public ITryAsyncOperation<TContext> DoAsync(Func<TContext, Task> operation)
        {
            return Try.DoAsync(context, operation);
        }

        public ITryAsyncOperation<TContext, T> DoAsync<T>(Func<TContext, Task<T>> operation)
        {
            return Try.DoAsync(context, operation);
        }
    }

    public static class Try
    {
        public static ContextualTryBuilder<TContext> With<TContext>(TContext context)
            where TContext : class
        {
            return new ContextualTryBuilder<TContext>(context);
        }


        public static ITryOperation<object> Do(Action operation)
        {
            return Do<object>(null, (_) => operation());
        }

        public static ITryOperation<object, T> Do<T>(Func<T> operation)
        {
            return Do<object, T>(null, (_) => operation());
        }

        internal static ITryOperation<TContext> Do<TContext>(TContext context, Action<TContext> operation)
            where TContext : class
        {
            return new TryOperation<TContext, Void>((ctx) => { operation(ctx); return Void.Value; }, context);
        }

        internal static ITryOperation<TContext, T> Do<TContext, T>(TContext context, Func<TContext, T> operation)
            where TContext : class
        {
            return new TryOperation<TContext, T>(operation, context);
        }



        public static ITryAsyncOperation<object> DoAsync(Func<Task> operation)
        {
            return DoAsync<object>(null, (_) => operation().ContinueWith(__ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion));
        }

        public static ITryAsyncOperation<object, T> DoAsync<T>(Func<Task<T>> operation)
        {
            return DoAsync<object, T>(null, (_) => operation());
        }

        internal static ITryAsyncOperation<TContext> DoAsync<TContext>(TContext context, Func<TContext, Task> operation)
            where TContext : class
        {
            return new TryAsyncOperation<TContext, Void>((ctx) => operation(ctx).ContinueWith(_ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion), context);
        }

        internal static ITryAsyncOperation<TContext, T> DoAsync<TContext, T>(TContext context, Func<TContext, Task<T>> operation)
            where TContext : class
        {
            return new TryAsyncOperation<TContext, T>(operation, context);
        }
    }

    #endregion Static Entry point
}