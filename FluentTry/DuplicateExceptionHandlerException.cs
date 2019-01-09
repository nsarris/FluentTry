using System;

namespace FluentTry
{
    public class DuplicateExceptionHandlerException : Exception
    {
        public DuplicateExceptionHandlerException() 
            : base($"Exception types with multiple handlers detected.")
        {
        }
    }

    #endregion Static Entry point
}