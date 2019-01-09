namespace FluentTry
{
    public enum ExceptionHandlerSequenceBehaviour
    {
        ThrowIfNotValid,
        AutoOrder,
        IgnoreAndGetFirst
    }

    internal class TryOpertationConfiguration
    {
        public ExceptionHandlerSequenceBehaviour ExceptionHandlerSequenceBehaviour { get; set; }
    }
}