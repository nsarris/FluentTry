using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public class TryBuilder<TContext>
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

        public TryBuilder<TContext> WithConfiguration(Func<TryOperationConfigurator, TryOperationConfigurator> configuratorDelegate)
        {
            this.configuration = configuratorDelegate(new TryOperationConfigurator()).Configuration;
            return this;
        }

        public ITryOperationWithContext<TContext> Do(Action<TContext> operation)
        {
            return Try.Do(context, operation, configuration);
        }

        public ITryOperationWithContext<TContext, T> Do<T>(Func<TContext, T> operation)
        {
            return Try.Do(context, operation, configuration);
        }

        public ITryOperationWithContext<TContext> Do(Func<TContext, Task> operation)
        {
            return Try.Do(context, operation, configuration);
        }

        public ITryOperationWithContext<TContext, T> Do<T>(Func<TContext, Task<T>> operation)
        {
            return Try.Do(context, operation, configuration);
        }
    }
}