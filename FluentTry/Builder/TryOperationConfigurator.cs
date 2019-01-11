using System;
using System.Threading.Tasks;

namespace FluentTry
{
    public class TryOperationConfigurator
    {
        internal TryOperationConfiguration Configuration { get; }

        internal TryOperationConfigurator()
        {
            Configuration = TryOperationConfiguration.Default;
        }

        internal TryOperationConfigurator(TryOperationConfiguration configuration)
        {
            Configuration = configuration;
        }

        public TryOperationConfigurator WithExceptionHandlerSequenceBehaviour(ExceptionHandlerSequenceBehaviour exceptionHandlerSequenceBehaviour)
        {
            Configuration.ExceptionHandlerSequenceBehaviour = exceptionHandlerSequenceBehaviour;
            return this;
        }

        public TryOperationConfigurator WithLoggerBehaviour(LoggerBehaviour loggerBehaviour)
        {
            Configuration.LoggerBehaviour = loggerBehaviour;
            return this;
        }

        public TryOperationConfigurator WithLoggerExceptionBehaviour(ExceptionBehaviour exceptionBehaviour)
        {
            Configuration.LoggerExceptionBehaviour = exceptionBehaviour;
            return this;
        }

        public TryOperationConfigurator WithFinallyExceptionBehaviour(ExceptionBehaviour exceptionBehaviour)
        {
            Configuration.FinallyExceptionBehaviour = exceptionBehaviour;
            return this;
        }

        public TryOperationConfigurator WithDefaultLoggerExceptionBehaviour(DefaultLoggerExceptionBehaviour loggerExceptionBehaviour)
        {
            Configuration.DefaultLoggerExceptionBehaviour = loggerExceptionBehaviour;
            return this;
        }

        public TryOperationConfigurator WithUnhandledExceptionBehaviour(UnhandledExceptionBehaviour unhandledExceptionBehaviour)
        {
            Configuration.UnhandledExceptionBehaviour = unhandledExceptionBehaviour;
            return this;
        }

        public TryOperationConfigurator WithDefaultLogger(Action<Exception, object> defaultLogger)
        {
            Configuration.DefaultLogger = new ActionWrapper<Exception, object>(defaultLogger);
            return this;
        }

        public TryOperationConfigurator WithDefaultLogger(Func<Exception, object, Task> defaultLogger)
        {
            Configuration.DefaultLogger = new AsyncActionWrapper<Exception, object>(defaultLogger);
            return this;
        }

        public TryOperationConfigurator WithDefaultLogger(Action<Exception> defaultLogger)
        {
            Configuration.DefaultLogger = new ActionWrapper<Exception, object>((e,_) => defaultLogger(e));
            return this;
        }

        public TryOperationConfigurator WithDefaultLogger(Func<Exception, Task> defaultLogger)
        {
            Configuration.DefaultLogger = new AsyncActionWrapper<Exception, object>((e, _) => defaultLogger(e));
            return this;
        }
    }
}