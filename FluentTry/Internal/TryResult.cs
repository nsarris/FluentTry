using System;

namespace FluentTry
{
    internal class TryResult<T> : ITryResult<T>
    {
        public T Value { get; }
        public T GetValueOrThrow()
        {
            Throw();
            return Value;
        }
        public TryResult(Exception e)
        {
            Exception = e;
            Success = e == null;
            IsFaulted = !Success;
        }
        public bool Success { get; }
        public bool IsFaulted { get; }
        public Exception Exception { get; }

        public void Throw()
        {
            if (Exception != null) throw Exception;
        }

        public static implicit operator bool(TryResult<T> tryResult)
        {
            return tryResult.Success;
        }

        public TryResult()
        {
            
        }

        public TryResult(T value)
        {
            Value = value;
        }

        public static implicit operator T(TryResult<T> tryResult)
        {
            return tryResult.Value;
        }
    }
}