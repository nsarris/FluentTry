using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FluentTry
{
    public class AsyncTry<TState, T>
    {
        private Task<Try<TState, T>> task;

        public AsyncTry(Task<Try<TState, T>> task)
        {
            this.task = task;
        }

        public AsyncTry(Try<TState, T> t)
        {
            this.task = Task.FromResult(t);
        }

        public TaskAwaiter<Try<TState, T>> GetAwaiter() => task.GetAwaiter();

        public AsyncTry<TState, T> Catch<TException>(Func<TException, T> handle)
            where TException : Exception
        {
            task = task.ChainAwait((t, h) => t.Result.Catch(h!), handle);
            return this;
        }

        public AsyncTry<TState, T> Catch<TException>(Func<TException, TState, T> handle)
            where TException : Exception
        {
            task = task.ChainAwait((t, h) => t.Result.Catch(h!), handle);
            return this;
        }

        public AsyncTry<TState, T> CatchAsync<TException>(Func<TException, Task<T>> handle)
            where TException : Exception
        {
            task = task.ChainAwait((t, h) => t.Result!.CatchAsync(h!), handle).ChainAwait(t => t.Result.task).Unwrap();
            return this;
        }

        public AsyncTry<TState, T> CatchAsync<TException>(Func<TException, TState, Task<T>> handle)
            where TException : Exception
        {
            task = task.ChainAwait((t, h) => t.Result!.CatchAsync(h!), handle).ChainAwait(t => t.Result.task).Unwrap();
            return this;
        }

        public async Task<T?> GetResultAsync()
        {
            var result = await task;
            return result.Result;
        }
    }
}
