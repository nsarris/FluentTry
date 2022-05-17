using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public static class Try
    {
        private static readonly Try<Void> VoidSucess = new(Void.Value);

        public static TryState<T> With<T>(T State)
        {
            return new TryState<T>(State);
        }

        public static Try<Void> Execute(Action action)
        {
            try
            {
                action();
                return VoidSucess;
            }
            catch (Exception ex)
            {
                return new Try<Void>(ex);
            }
        }

        public static Try<TResult> Execute<TResult>(Func<TResult> function)
        {
            try
            {
                return new Try<TResult>(function());
            }
            catch (Exception ex)
            {
                return new Try<TResult>(ex);
            }
        }

        public static Try<TState, Void> Execute<TState>(Action<TState> action, TState State)
        {
            try
            {
                action(State);
                return new Try<TState, Void>(State, Void.Value);
            }
            catch (Exception ex)
            {
                return new Try<TState, Void>(State, ex);
            }
        }

        public static Try<TState, TResult> Execute<TState, TResult>(Func<TState, TResult> function, TState State)
        {
            try
            {
                return new Try<TState, TResult>(State, function(State));
            }
            catch (Exception ex)
            {
                return new Try<TState, TResult>(State, ex);
            }
        }

        public static async Task<Try<Void>> ExecuteAsync(Func<Task> action)
        {
            try
            {
                await action();
                return VoidSucess;
            }
            catch (Exception ex)
            {
                return new Try<Void>(ex);
            }
        }

        public static AsyncTry<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> function)
        {
            try
            {
                return new(function().ChainAwait(task => new Try<TResult>(task)));
            }
            catch (Exception ex)
            {
                return new(new Try<TResult>(ex));
            }
        }

        public static AsyncTry<TState, Void> ExecuteAsync<TState>(Func<TState, Task> action, TState State)
        {
            try
            {
                return new(action(State).ChainAwait(task => new Try<TState, Void>(State, task)));
            }
            catch (Exception ex)
            {
                return new(new Try<TState, Void>(State, ex));
            }
        }

        public static AsyncTry<TState, TResult> ExecuteAsync<TState, TResult>(Func<TState, Task<TResult>> action, TState State)
        {
            try
            {
                return new(action(State).ChainAwait(task => new Try<TState, TResult>(State, task)));
            }
            catch (Exception ex)
            {
                return new(new Try<TState, TResult>(State, ex));
            }
        }
    }
}
