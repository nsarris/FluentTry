using System;

namespace FluentTry
{
    internal class TryOperationConfiguration
    {
        private static TryOperationConfiguration _default = new TryOperationConfiguration();
        public static TryOperationConfiguration Default { get => _default.Clone(); set => _default = value; }
        public static TryOperationConfiguration Initial { get; } = new TryOperationConfiguration();
        
        private TryOperationConfiguration()
        {

        }

        public IActionWrapper<Exception, object> DefaultLogger { get; set; } = null;
        public LoggerBehaviour LoggerBehaviour { get; set; } = LoggerBehaviour.Everything;
        public ExceptionBehaviour LoggerExceptionBehaviour { get; set; } = ExceptionBehaviour.Throw;
        public ExceptionBehaviour FinallyExceptionBehaviour { get; set; } = ExceptionBehaviour.Throw;
        public DefaultLoggerExceptionBehaviour DefaultLoggerExceptionBehaviour { get; set; } = DefaultLoggerExceptionBehaviour.Throw;
        public UnhandledExceptionBehaviour UnhandledExceptionBehaviour { get; set; } = UnhandledExceptionBehaviour.Throw;
        public ExceptionHandlerSequenceBehaviour ExceptionHandlerSequenceBehaviour { get; set; } = ExceptionHandlerSequenceBehaviour.ThrowIfNotValid;

        public TryOperationConfiguration Clone()
        {
            return new TryOperationConfiguration()
            {
                UnhandledExceptionBehaviour = UnhandledExceptionBehaviour,
                LoggerBehaviour = LoggerBehaviour,
                ExceptionHandlerSequenceBehaviour = ExceptionHandlerSequenceBehaviour,
                DefaultLogger = DefaultLogger
            };
        }
    }
}