using System;

namespace FluentTry
{
    public class InvalidExceptionHandlerSequenceException : Exception
    {
        public InvalidExceptionHandlerSequenceException()
            : base($"The sequence of exception handlers has detected super classes before sub classes.")
        {
        }
    }
}