using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FluentTry
{
    public static class TaskExtensions
    {
        public async static Task<T> GetValueOrThrow<T>(this Task<ITryResult<T>> task)
        {
            return (await task).GetValueOrThrow();
        }

        public static Task<TNewResult> ContinueWith<T, TNewResult>(this Task<T> task, Func<Task<T>, Task<TNewResult>> continuationFunction, object state)
        {
            return ContinueWith(task, continuationFunction, state, CancellationToken.None);
        }

        public static Task<TNewResult> ContinueWith<T, TNewResult>(this Task<T> task, Func<Task<T>, Task<TNewResult>> continuationFunction)
        {
            return ContinueWith(task, continuationFunction, null, CancellationToken.None);
        }

        public static Task<TNewResult> ContinueWith<T, TNewResult>(this Task<T> task, Func<Task<T>, Task<TNewResult>> continuationFunction, object state, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<TNewResult>();
            task.ContinueWith((t,s) =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    tcs.SetCanceled();
                }
                continuationFunction(t).ContinueWith((t2,s2) =>
                {
                    if (cancellationToken.IsCancellationRequested || t2.IsCanceled)
                    {
                        tcs.TrySetCanceled();
                    }
                    else if (t2.IsFaulted)
                    {
                        tcs.TrySetException(t2.Exception);
                    }
                    else
                    {
                        tcs.TrySetResult(t2.Result);
                    }
                }, s);
            }, state);
            return tcs.Task;
        }

        public static Task<TNewResult> ContinueWith<T, TNewResult>(this Task<T> task, Func<Task<T>, object, Task<TNewResult>> continuationFunction, object state)
        {
            return ContinueWith(task, continuationFunction, state, CancellationToken.None);
        }

        public static Task<TNewResult> ContinueWith<T, TNewResult>(this Task<T> task, Func<Task<T>, object, Task<TNewResult>> continuationFunction)
        {
            return ContinueWith(task, continuationFunction, null, CancellationToken.None);
        }

        public static Task<TNewResult> ContinueWith<T, TNewResult>(this Task<T> task, Func<Task<T>, object, Task<TNewResult>> continuationFunction, object state, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<TNewResult>();
            task.ContinueWith((t, s) =>
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    tcs.SetCanceled();
                }
                continuationFunction(t, s).ContinueWith((t2, s2) =>
                {
                    if (cancellationToken.IsCancellationRequested || t2.IsCanceled)
                    {
                        tcs.TrySetCanceled();
                    }
                    else if (t2.IsFaulted)
                    {
                        tcs.TrySetException(t2.Exception);
                    }
                    else
                    {
                        tcs.TrySetResult(t2.Result);
                    }
                }, s);
            }, state);
            return tcs.Task;
        }
    }
}
