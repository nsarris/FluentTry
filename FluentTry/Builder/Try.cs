using System;
using System.Text;
using System.Threading.Tasks;

namespace FluentTry
{
    public static class Try
    {
        public static TryBuilder WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate)
        {
            return new TryBuilder().WithConfiguration(configuratorDelegate);
        }

        public static TryBuilder<TContext> WithContext<TContext>(TContext context)
            where TContext : class
        {
            return new TryBuilder<TContext>(context);
        }


        public static ITryOperation Do(Action operation)
        {
            return Do<object>(null, (_) => operation());
        }

        public static ITryOperation<T> Do<T>(Func<T> operation)
        {
            return Do<object, T>(null, (_) => operation());
        }

        internal static TryOperation<TContext, Void> Do<TContext>(TContext context, Action<TContext> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryOperation<TContext, Void>((ctx) => { operation(ctx); return Void.Value; }, context, configuration);
        }

        internal static TryOperation<TContext, T> Do<TContext, T>(TContext context, Func<TContext, T> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryOperation<TContext, T>(operation, context, configuration);
        }



        public static ITryOperation DoAsync(Func<Task> operation)
        {
            return DoAsync<object>(null, (_) => operation().ContinueWith(__ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion));
        }

        public static ITryOperation<T> DoAsync<T>(Func<Task<T>> operation)
        {
            return DoAsync<object, T>(null, (_) => operation());
        }

        internal static TryOperation<TContext, Void> DoAsync<TContext>(TContext context, Func<TContext, Task> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryOperation<TContext, Void>((ctx) => operation(ctx).ContinueWith(_ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion), context, configuration);
        }

        internal static TryOperation<TContext, T> DoAsync<TContext, T>(TContext context, Func<TContext, Task<T>> operation, TryOpertationConfiguration configuration = null)
            where TContext : class
        {
            return new TryOperation<TContext, T>(operation, context, configuration);
        }
    }
}