using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using FluentAssertions.Primitives;

namespace FluentTry.Tests
{
    public class Try_CatchAsync_Tests
    {
        private static int Increase(int _) => throw new InvalidOperationException();
        private static async Task<int> IncreaseAsync(int _)
        {
            await Task.Delay(100); throw new InvalidOperationException();
        }

        private static Task<int> CompletedIncreaseAsync(int _)
        {
            throw new InvalidOperationException();
        }

        private async Task AssertResult<TResult>(TResult result, Func<AsyncTry<TResult>> f)
        {
            (await f()).Should().BeTryResult(result);
            (await f().GetResultAsync()).Should().Be(result);
        }

        private async Task AssertException<TResult, TException>(Func<AsyncTry<TResult>> f)
            where TException : Exception
        {
            (await f()).Should().BeTryException<int, TException>();
            await f.Invoking(async x => await x().GetResultAsync()).Should().ThrowExactlyAsync<TException>();
        }

        [Fact]
        public async Task Should_Not_CatchAsync_Exception()
        {
            await AssertException<int, InvalidOperationException>(() => 
                Try.Execute(() => Increase(1))
                .CatchAsync<IndexOutOfRangeException>(e => Task.FromResult(10)));
        }

        [Fact]
        public async Task Should_Catch_Exception()
        {
            await AssertResult(10, () =>
                Try.Execute(() => Increase(1))
                .CatchAsync<InvalidOperationException>(e => Task.FromResult(10)));
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_Async()
        {
            await AssertException<int, InvalidOperationException>(() =>
                Try.ExecuteAsync(() => IncreaseAsync(1))
                .CatchAsync<IndexOutOfRangeException>(e => Task.FromResult(10)));
        }

        [Fact]
        public async Task Should_Catch_Exception_Async()
        {
            await AssertResult(10, () => 
                Try.ExecuteAsync(() => IncreaseAsync(1))
                .CatchAsync<InvalidOperationException>(e => Task.FromResult(10)));
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_Completed_Async()
        {
            await AssertException<int, InvalidOperationException>(() =>
                Try.ExecuteAsync(() => CompletedIncreaseAsync(1))
                .CatchAsync<IndexOutOfRangeException>(e => Task.FromResult(10)));
        }

        [Fact]
        public async Task Should_Catch_Exception_Completed_Async()
        {
            await AssertResult(10, () =>
                Try.ExecuteAsync(() => CompletedIncreaseAsync(1))
                .CatchAsync<InvalidOperationException>(e => Task.FromResult(10)));
        }





        [Fact]
        public async Task Should_Not_Catch_Exception_With_State()
        {
            var r = await Try.Execute(c => Increase(c.Id), new TestState(1))
                .CatchAsync<IndexOutOfRangeException>(e => Task.FromResult(10));

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public async Task Should_Catch_Exception_With_State()
        {
            var r = await Try.Execute(c => Increase(c.Id), new TestState(1))
                .CatchAsync<InvalidOperationException>(e => Task.FromResult(10));

            r.Should().BeTryResult(10);
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_With_State_Async()
        {
            var r = await Try.ExecuteAsync(c => IncreaseAsync(c.Id), new TestState(1))
                .CatchAsync<IndexOutOfRangeException>(e => Task.FromResult(10));

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public async Task Should_Catch_Exception_With_State_Async()
        {
            var r = await Try.ExecuteAsync(c => IncreaseAsync(c.Id), new TestState(1))
                .CatchAsync<InvalidOperationException>(e => Task.FromResult(10));

            r.Should().BeTryResult(10);
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_With_State_Completed_Async()
        {
            var r = await Try.ExecuteAsync(c => CompletedIncreaseAsync(c.Id), new TestState(1))
                .CatchAsync<IndexOutOfRangeException>(e => Task.FromResult(10));

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public async Task Should_Catch_Exception_With_State_Completed_Async()
        {
            var r = await Try.ExecuteAsync(c => CompletedIncreaseAsync(c.Id), new TestState(1))
                .CatchAsync<InvalidOperationException>(e => Task.FromResult(10));

            r.Should().BeTryResult(10);
        }
    }
}
