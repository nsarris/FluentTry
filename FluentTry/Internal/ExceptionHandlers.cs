using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentTry
{
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
            return handlers.FirstOrDefault(handler => handler.Key.IsAssignableFrom(exceptionType)).Value?.FirstOrDefault();
        }

        public IExceptionHandler<TContext, T> GetSortedHandler(Type exceptionType)
        {
            return handlers
                .OrderByDescending(x => x.Key.GetHierarchyDepth())
                .FirstOrDefault(handler => handler.Key.IsAssignableFrom(exceptionType)).Value?.FirstOrDefault();
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
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<Task> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TException, Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TContext, Task> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TException, TContext, Task> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<TContext, Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void AddAsyncHandler<TException>(Func<Exception, TContext, Task<T>> handler)
            where TException : Exception
        {
            handlers.Add(typeof(TException), new ExceptionHandler<TException, TContext, T>(handler));
        }

        public void SetFinallyHandler(Action handler)
        {
            finallyHandler = new ExceptionHandler<Exception, TContext, T>(handler);
        }

        public void SetAsyncFinallyHandler(Func<Task> handler)
        {
            finallyHandler = new ExceptionHandler<Exception, TContext, T>(handler);
        }

        public void SetFinallyHandler(Action<TContext> handler)
        {
            finallyHandler = new ExceptionHandler<Exception, TContext, T>(handler);
        }

        public void SetAsyncFinallyHandler(Func<TContext, Task> handler)
        {
            finallyHandler = new ExceptionHandler<Exception, TContext, T>(handler);
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
}