using System;
using System.Threading.Tasks;

namespace FluentTry
{
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
}