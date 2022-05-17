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
    public class TestState
    {
        public int Id { get; set; }

        public TestState(int id)
        {
            Id = id;
        }
    }

    public class Try_Catch_Tests
    {
        private static void Do(int _) => throw new InvalidOperationException();
        private static int Increase(int _) => throw new InvalidOperationException();
        private static async Task<int> IncreaseAsync(int _)
        {
            await Task.Delay(100); throw new InvalidOperationException();
        }

        private static Task<int> CompletedIncreaseAsync(int _)
        {
            throw new InvalidOperationException();
        }

        [Fact]
        public void Should_Not_Catch_Exception()
        {
            var r = Try.Execute(() => Increase(1))
                .Catch<IndexOutOfRangeException>(e => 10);

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public void Should_Not_Catch_Exception_Void()
        {
            var r = Try.Execute(() => Do(1))
                .Catch<IndexOutOfRangeException>(e => Void.Value);

            r.Should().BeTryException<Void, InvalidOperationException>();
        }

        [Fact]
        public void Should_Catch_Exception()
        {
            var r = Try.Execute(() => Increase(1))
                .Catch<InvalidOperationException>(e => 10);

            r.Should().BeTryResult(10);
        }


        [Fact]
        public void Should_Catch_Exception_Void()
        {
            var r = Try.Execute(() => Do(1))
                .Catch<InvalidOperationException>(e => Void.Value);

            r.Should().BeTryResult(Void.Value);
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_Async()
        {
            var r = await Try.ExecuteAsync(() => IncreaseAsync(1))
                .Catch<IndexOutOfRangeException>(e => 10);

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public async Task Should_Catch_Exception_Async()
        {
            var r = await Try.ExecuteAsync(() => IncreaseAsync(1))
                .Catch<InvalidOperationException>(e => 10);

            r.Should().BeTryResult(10);
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_Completed_Async()
        {
            var r = await Try.ExecuteAsync(() => CompletedIncreaseAsync(1))
                .Catch<IndexOutOfRangeException>(e => 10);

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public async Task Should_Catch_Exception_Completed_Async()
        {
            var r = await Try.ExecuteAsync(() => CompletedIncreaseAsync(1))
                .Catch<InvalidOperationException>(e => 10);

            r.Should().BeTryResult(10);
        }



        

        

        [Fact]
        public void Should_Not_Catch_Exception_With_State()
        {
            var r = Try.Execute(c => Increase(c.Id), new TestState(1))
                .Catch<IndexOutOfRangeException>(e => 10);

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public void Should_Catch_Exception_With_State()
        {
            var r = Try.Execute(c => Increase(c.Id), new TestState(1))
                .Catch<InvalidOperationException>(e => 10);

            r.Should().BeTryResult(10);
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_With_State_Async()
        {
            var r = await Try.ExecuteAsync(c => IncreaseAsync(c.Id), new TestState(1))
                .Catch<IndexOutOfRangeException>(e => 10);

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public async Task Should_Catch_Exception_With_State_Async()
        {
            var r = await Try.ExecuteAsync(c => IncreaseAsync(c.Id), new TestState(1))
                .Catch<InvalidOperationException>(e => 10);

            r.Should().BeTryResult(10);
        }

        [Fact]
        public async Task Should_Not_Catch_Exception_With_State_Completed_Async()
        {
            var r = await Try.ExecuteAsync(c => CompletedIncreaseAsync(c.Id), new TestState(1))
                .Catch<IndexOutOfRangeException>(e => 10);

            r.Should().BeTryException<int, InvalidOperationException>();
        }

        [Fact]
        public async Task Should_Catch_Exception_With_State_Completed_Async()
        {
            var r = await Try.ExecuteAsync(c => CompletedIncreaseAsync(c.Id), new TestState(1))
                .Catch<InvalidOperationException>(e => 10);

            r.Should().BeTryResult(10);
        }
    }
}
