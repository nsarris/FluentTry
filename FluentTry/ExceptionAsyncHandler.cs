using System;
using System.Threading.Tasks;

namespace FluentTry
{
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
}