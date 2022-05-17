using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public class Try<TState, T> : Try<T>
    {
        internal Try(TState state, T result) : base(result)
        {
            State = state;
        }

        internal Try(TState state, Exception exception) : base(exception)
        {
            State = state;
        }

        internal Try(TState state, Task task) : base(task)
        {
            State = state;
        }

        public TState State { get; }

        public Try<TState, T> Catch<TException>(Func<TException, TState, T> handle)
            where TException : Exception
        {
            if (Exception is TException exception)
            {
                try
                {
                    Result = handle(exception, State);
                }
                catch (Exception ex)
                {
                    Exception = ex;
                }
            }

            return this;
        }

        public new Try<TState, T> Catch<TException>(Func<TException, T> handle)
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

        public AsyncTry<TState, T> CatchAsync<TException>(Func<TException, TState, Task<T>> handle)
            where TException : Exception            
        {
            if (Exception is TException exception)
            {
                try
                {
                    return new(handle(exception, State).ChainAwait((task, t) =>
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

        public new AsyncTry<TState, T> CatchAsync<TException>(Func<TException, Task<T>> handle)
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
    }
}
