namespace FluentTry
{
    public class TryOperationConfigurator
    {
        internal TryOpertationConfiguration Configuration { get; } = new TryOpertationConfiguration();

        public TryOperationConfigurator WithExceptionHandlerSequenceBehaviour(ExceptionHandlerSequenceBehaviour exceptionHandlerSequenceBehaviour)
        {
            Configuration.ExceptionHandlerSequenceBehaviour = exceptionHandlerSequenceBehaviour;
            return this;
        }
    }
}