using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FluentTry
{
    public class AsyncTry<T>
    {
        private Task<Try<T>> task;

        public AsyncTry(Task<Try<T>> task)
        {
            this.task = task;
        }

        public AsyncTry(Try<T> task)
        {
            this.task = Task.FromResult(task);
        }

        public TaskAwaiter<Try<T>> GetAwaiter() => task.GetAwaiter();

        public AsyncTry<T> Catch<TException>(Func<TException, T> handle)
            where TException : Exception
        {
            return new AsyncTry<T>(task.ChainAwait((t, h) => t.Result.Catch(h!), handle));
        }

        public AsyncTry<T> CatchAsync<TException>(Func<TException, Task<T>> handle)
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
