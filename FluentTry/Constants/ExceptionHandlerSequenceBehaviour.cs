namespace FluentTry
{
    public enum ExceptionHandlerSequenceBehaviour
    {
        ThrowIfNotValid,
        AutoOrder,
        IgnoreAndGetFirst
    }

    public enum LoggerBehaviour
    {
        Everything,
        UnhandledOnly
    }

    public enum UnhandledExceptionBehaviour
    {
        Throw,
        Swallow
    }

    public enum ExceptionBehaviour
    {
        Throw,
        Swallow,
        RedirectToDefaultLogger
    }

    public enum DefaultLoggerExceptionBehaviour
    {
        Throw,
        Swallow
    }
}