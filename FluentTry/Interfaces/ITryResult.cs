using System;

namespace FluentTry
{
    public interface ITryResult
    {
        bool Success { get; }
        bool IsFaulted { get; }
        Exception Exception { get; }
        void Throw();
    }

    public interface ITryResult<out T> : ITryResult
    {
        T Value { get; }
        T GetValueOrThrow();
    }
}