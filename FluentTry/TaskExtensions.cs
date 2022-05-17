using System;
using System.Threading;
using System.Threading.Tasks;

namespace FluentTry
{
    internal static class TaskExtensions
    {
        private static readonly TaskContinuationOptions continuationOptions
            = TaskContinuationOptions.DenyChildAttach | TaskContinuationOptions.ExecuteSynchronously;

        private static TaskScheduler TaskScheduler => TaskScheduler.Default;


        //public static Task<TResult> ChainAwait<TState, TResult>(this Task task, Func<Task, TState?, TResult> func, TState? state, CancellationToken cancellationToken)
        //    => task.ContinueWith((t, s) => func(t, (TState?)s), state, cancellationToken, continuationOptions, TaskScheduler);

        //public static Task<TResult> ChainAwait<TState, TResult>(this Task task, Func<Task, TState?, TResult> func, TState? state)
        //    => ChainAwait(task, func, state, CancellationToken.None);

        public static Task<TResult> ChainAwait<TResult>(this Task task, Func<Task, TResult> func, CancellationToken cancellationToken)
            => task.ContinueWith(t => func(t), cancellationToken, continuationOptions, TaskScheduler);

        public static Task<TResult> ChainAwait<TResult>(this Task task, Func<Task, TResult> func)
            => ChainAwait(task, func, CancellationToken.None);


        public static Task<TResult> ChainAwait<T, TState, TResult>(this Task<T> task, Func<Task<T>, TState?, TResult> func, TState? state, CancellationToken cancellationToken)
            => task.ContinueWith((t, s) => func(t, (TState?)s), state, cancellationToken, continuationOptions, TaskScheduler);

        public static Task<TResult> ChainAwait<T, TState, TResult>(this Task<T> task, Func<Task<T>, TState?, TResult> func, TState? state)
            => ChainAwait(task, func, state, CancellationToken.None);

        public static Task<TResult> ChainAwait<T, TResult>(this Task<T> task, Func<Task<T>, TResult> func, CancellationToken cancellationToken)
            => task.ContinueWith(t => func(t), cancellationToken, continuationOptions, TaskScheduler);

        public static Task<TResult> ChainAwait<T, TResult>(this Task<T> task, Func<Task<T>, TResult> func)
            => ChainAwait(task, func, CancellationToken.None);
    }
}
