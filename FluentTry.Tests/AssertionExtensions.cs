using System;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace FluentTry.Tests
{
    public static class AssertionExtensions
    {
        public static AndConstraint<Try<T>> BeTryResult<T>(this ObjectAssertions assertions, T result)
        {
            var r = assertions.BeAssignableTo<Try<T>>().Subject;

            AssertTryResult(r, result);

            return new(r);
        }

        public static AndConstraint<Try<TResult>> BeTryException<TResult, TException>(this ObjectAssertions assertions, TException? exception = null)
            where TException : Exception
        {
            var r = assertions.BeAssignableTo<Try<TResult>>().Subject;

            AssertTryException(r, exception);

            return new(r);
        }

        public static AndConstraint<Try<TState, TResult>> BeTryException<TState, TResult, TException>(this ObjectAssertions assertions, TException? exception = null)
            where TException : Exception
        {
            var r = assertions.BeAssignableTo<Try<TState, TResult>>().Subject;

            AssertTryException(r, exception);
            
            return new(r);
        }

        private static void AssertTryResult<T>(Try<T> r, T result)
        {
            r.Result.Should().Be(result);
            r.IsFaulted.Should().BeFalse();
            r.Exception.Should().BeNull();
        }

        private static void AssertTryException<TResult, TException>(Try<TResult> r, TException? exception = null)
            where TException : Exception
        {
            r.IsFaulted.Should().BeTrue();
            r.Invoking(x => x.Result).Should().ThrowExactly<TException>();
            r.Invoking(x => x.Rethrow()).Should().ThrowExactly<TException>();

            if (exception is not null)
                r.Exception.Should().Be(exception);
        }
    }
}
