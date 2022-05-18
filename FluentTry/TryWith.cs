using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public class TryWith<TState>
    {
        private readonly TState State;

        public TryWith(TState State)
        {
            this.State = State;
        }

        public Try<TState, Void> Execute(Action<TState> action)
            => Try.Execute(action, State);

        public Try<TState, TResult> Execute<TResult>(Func<TState, TResult> function)
            => Try.Execute(function, State);

        public AsyncTry<TState, Void> ExecuteAsync(Func<TState, Task> action)
            => Try.ExecuteAsync(action, State);

        public AsyncTry<TState, TResult> ExecuteAsync<TResult>(Func<TState, Task<TResult>> function)
            => Try.ExecuteAsync(function, State);
    }
}
