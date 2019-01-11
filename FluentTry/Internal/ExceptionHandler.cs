using System;
using System.Threading.Tasks;

namespace FluentTry
{
    internal class ExceptionHandler<TException, TContext, T> : IExceptionHandler<TContext, T>
        where TException : Exception
        where TContext : class
    {
        private readonly IFuncWrapper<TContext, TException, T> executor;

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




        public ExceptionHandler(Func<TException, Task<T>> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<TException, Task> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<Task> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<Task<T>> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<TException, TContext, Task<T>> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<TException, TContext, Task> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<TContext, Task> handler)
            : this(handler as Delegate) { }

        public ExceptionHandler(Func<TContext, Task<T>> handler)
            : this(handler as Delegate) { }


        private ExceptionHandler(Delegate executor)
        {
            this.executor = GetExceptionHandlerWrapper(executor);
        }


        private IFuncWrapper<TContext, TException, T> GetExceptionHandlerWrapper(Delegate executor)
        {
            switch (executor)
            {
                case Action actionHandler:
                    return new FuncWrapper<TContext, TException, T>((_, __) => { actionHandler(); return default; });
                case Action<TException> actionWithException:
                    return new FuncWrapper<TContext, TException, T>((_, e) => { actionWithException(e); return default; });
                case Func<T> funcHandler:
                    return new FuncWrapper<TContext, TException, T>((_, __) => funcHandler());
                case Func<TException, T> funcWithException:
                    return new FuncWrapper<TContext, TException, T>((_, e) => funcWithException(e));
                case Action<TContext> actionHandlerWithContext:
                    return new FuncWrapper<TContext, TException, T>((context, __) => { actionHandlerWithContext(context); return default; });
                case Action<TException, TContext> actionHandlerWithExceptionAndContext:
                    return new FuncWrapper<TContext, TException, T>((context, e) => { actionHandlerWithExceptionAndContext(e, context); return default; });
                case Func<TContext, T> funcHandlerWithContext:
                    return new FuncWrapper<TContext, TException, T>((context, __) => funcHandlerWithContext(context));
                case Func<TException, TContext, T> funcHandlerWithExceptionAndContext:
                    return new FuncWrapper<TContext, TException, T>((context, e) => funcHandlerWithExceptionAndContext(e, context));

                case Func<Task<T>> funcHandler:
                    return new AsyncFuncWrapper<TContext, TException, T>((_, __) => funcHandler());
                case Func<TException, Task<T>> funcWithException:
                    return new AsyncFuncWrapper<TContext, TException, T>((_, e) => funcWithException(e));
                case Func<Task> actionHandler:
                    return new AsyncFuncWrapper<TContext, TException, T>((_, __) => actionHandler().ContinueWith(___ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion));
                case Func<TException, Task> actionWithException:
                    return new AsyncFuncWrapper<TContext, TException, T>((_, e) => actionWithException(e).ContinueWith(___ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion));
                case Func<TContext, Task<T>> funcHandlerWithContext:
                    return new AsyncFuncWrapper<TContext, TException, T>((context, __) => funcHandlerWithContext(context));
                case Func<TException, TContext, Task<T>> funcWithExceptionAndContext:
                    return new AsyncFuncWrapper<TContext, TException, T>((context, e) => funcWithExceptionAndContext(e, context));
                case Func<TContext, Task> actionHandlerWithContext:
                    return new AsyncFuncWrapper<TContext, TException, T>((context, __) => actionHandlerWithContext(context).ContinueWith(_ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion));
                case Func<TException, TContext, Task> actionWithExceptionAndContext:
                    return new AsyncFuncWrapper<TContext, TException, T>((context, e) => actionWithExceptionAndContext(e, context).ContinueWith(_ => default(T), TaskContinuationOptions.OnlyOnRanToCompletion));

                default:
                    throw new NotSupportedException("Unsupported exception handler delegate type.");
            }
        }

        public T Execute(TContext context, TException e)
        {
            return executor.Invoke(context, e);
        }

        public T Execute(TContext context, Exception e)
        {
            return Execute(context, (TException)e);
        }

        public Task<T> ExecuteAsync(TContext context, TException e)
        {
            return executor.InvokeAsync(context, e);
        }

        public Task<T> ExecuteAsync(TContext context, Exception e)
        {
            return ExecuteAsync(context, (TException)e);
        }
    }
}