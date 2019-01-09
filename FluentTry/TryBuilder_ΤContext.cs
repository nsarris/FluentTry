using System;
using System.Threading.Tasks;

namespace FluentTry
{
    internal class TryBuilder<TContext> : ITryBuilder<TContext>
        where TContext : class
    {
        private readonly TContext context;
        private TryOpertationConfiguration configuration = new TryOpertationConfiguration();

        internal TryBuilder(TContext context, TryOpertationConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        internal TryBuilder(TContext context)
        {
            this.context = context;
        }

        public ITryBuilder<TContext> WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate)
        {
            this.configuration = configuratorDelegate(new TryOperationConfigurator()).Configuration;
            return this;
        }

        public ITryOperation<TContext> Do(Action<TContext> operation)
        {
            return Try.Do(context, operation);
        }

        public ITryOperation<TContext, T> Do<T>(Func<TContext, T> operation)
        {
            return Try.Do(context, operation);
        }

        public ITryAsyncOperation<TContext> DoAsync(Func<TContext, Task> operation)
        {
            return Try.DoAsync(context, operation);
        }

        public ITryAsyncOperation<TContext, T> DoAsync<T>(Func<TContext, Task<T>> operation)
        {
            return Try.DoAsync(context, operation);
        }
    }
}