using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public class TryBuilder
    {
        private TryOpertationConfiguration configuration = new TryOpertationConfiguration();

        internal TryBuilder()
        {

        }

        public TryBuilder WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate)
        {
            this.configuration = configuratorDelegate(new TryOperationConfigurator()).Configuration;
            return this;
        }

        public ITryOperation Do(Action operation)
        {
            return Try.Do<object>(null, (_) => operation(), configuration);
        }

        public ITryOperation<T> Do<T>(Func<T> operation)
        {
            return Try.Do<object, T>(null, (_) => operation(), configuration);
        }

        public ITryOperation Do(Func<Task> operation)
        {
            return Try.Do<object>(null, (_) => operation().ContinueWith(__ => Void.Value, continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion), configuration);
        }

        public ITryOperation<T> Do<T>(Func<Task<T>> operation)
        {
            return Try.Do<object, T>(null, (_) => operation(), configuration);
        }

        public TryBuilder<TContext> WithContext<TContext>(TContext context)
            where TContext : class
        {
            return new TryBuilder<TContext>(context, configuration);
        }
    }
}