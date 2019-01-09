using System;
using System.Threading.Tasks;

namespace FluentTry
{
    internal class TryBuilder : ITryBuilder
    {
        private TryOpertationConfiguration configuration = new TryOpertationConfiguration();

        public ITryBuilder WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate)
        {
            this.configuration = configuratorDelegate(new TryOperationConfigurator()).Configuration;
            return this;
        }

        public ITryOperation<object> Do(Action operation)
        {
            return Try.Do<object>(null, (_) => operation());
        }

        public ITryOperation<object, T> Do<T>(Func<T> operation)
        {
            return Try.Do<object, T>(null, (_) => operation());
        }

        public ITryAsyncOperation<object> DoAsync(Func<Task> operation)
        {
            return Try.DoAsync<object>(null, (_) => operation().ContinueWith(__ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion));
        }

        public ITryAsyncOperation<object, T> DoAsync<T>(Func<Task<T>> operation)
        {
            return Try.DoAsync<object, T>(null, (_) => operation());
        }

        public ITryBuilder<TContext> WithContext<TContext>(TContext context)
            where TContext : class
        {
            return new TryBuilder<TContext>(context, configuration);
        }
    }
}