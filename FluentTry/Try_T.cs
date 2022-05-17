using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace FluentTry
{
    public class Try<T>
    {
        internal Try(T? result)
        {
            Result = result;
        }

        internal Try(Exception exception)
        {
            Exception = exception;
        }

        internal Try(Task task)
        {
            FromTask(task);
        }

        private T? result;
        private Exception? exception;
        private ExceptionDispatchInfo? originalDispatchInfo;

        public bool IsFaulted => Exception is not null;

        public Exception? Exception
        {
            get => exception;
            internal set
            {
                result = default;
                if (exception != value)
                {
                    exception = value;
                    originalDispatchInfo = exception is null ? null : ExceptionDispatchInfo.Capture(exception);
                }
            }
        }

        public T? Result
        {
            get
            {
                return Exception != null ? throw Rethrow()! : result;
            }
            internal set
            {
                result = value;
                exception = null;
            }
        }

        public Try<T> Catch<TException>(Func<TException, T> handle)
            where TException : Exception
        {
            if (Exception is TException exception)
            {
                try
                {
                    Result = handle(exception);
                }
                catch (Exception ex)
                {
                    Exception = ex;
                }
            }

            return this;
        }

        public AsyncTry<T> CatchAsync<TException>(Func<TException, Task<T>> handle)
            where TException : Exception
        {
            if (Exception is TException exception)
            {
                try
                {
                    return new(handle(exception).ChainAwait((task, t) =>
                    {
                        t!.FromTask(task);
                        return t;
                    }, this));
                }
                catch (Exception ex)
                {
                    Exception = ex;
                }
            }

            return new(this);
        }

        public override string ToString() => Exception != null ? $"Exception: {Exception}" : $"Result: {result}";

        public Exception? Rethrow()
        {
            if (Exception != null
                && originalDispatchInfo != null)
            {
                originalDispatchInfo.Throw();
            }
            return Exception;
        }

        internal void FromTask(Task task)
        {
            if (task.Status == TaskStatus.RanToCompletion)
            {
                if (task is Task<T> t)
                    Result = t.Result;
            }
            else if (task.Exception is not null)
            {
                Exception = task.Exception is AggregateException ae && ae.InnerExceptions.Count == 1 ?
                    ae.InnerException : task.Exception;
            }
            else if (task.IsCanceled)
            {
                Exception = new OperationCanceledException();
            }
            else
            {
                Exception = new InvalidOperationException("Explain");
            }
        }
    }
}
