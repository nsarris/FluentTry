using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentTry.Tests
{
    public class Try_Execute_Tests
    {
        private static int Increase(int i) => i + 1;
        private static async Task<int> IncreaseAsync(int i)
        {
            await Task.Delay(10); return i + 1;
        }

        public class State
        {
            public int Value { get; set; }
        }

        [Fact]
        public void Should_Execute_Void()
        {
            var state = new State() { Value = 1 };
            var r = Try.Execute(() => { state.Value = Increase(state.Value); });

            r.Should().BeTryResult(Void.Value);
            state.Value.Should().Be(2); 
        }

        [Fact]
        public void Should_Execute()
        {
            var r = Try.Execute(() => Increase(1));

            r.Should().BeTryResult(2);
        }

        [Fact]
        public void Should_Execute_Void_With_State()
        {
            var state = new State() { Value = 1 };
            var r = Try.With(state).Execute(ctx => { ctx.Value = Increase(ctx.Value); });

            r.Should().BeTryResult(Void.Value);
            state.Value.Should().Be(2);
        }

        [Fact]
        public void Should_Execute_With_State()
        {
            var r = Try.With(new State { Value = 1 }).Execute(ctx => Increase(ctx.Value));

            r.Should().BeTryResult(2);
        }

        [Fact]
        public async Task Should_Execute_Void_Async()
        {
            var state = new State() { Value = 1 };
            var r = await Try.ExecuteAsync(async() => { state.Value = await IncreaseAsync(state.Value); });

            r.Should().BeTryResult(Void.Value);
            state.Value.Should().Be(2);
        }


        [Fact]
        public async Task Should_Execute_Async()
        {
            var r = await Try.ExecuteAsync(() => IncreaseAsync(1));

            r.Should().BeTryResult(2);
        }

        [Fact]
        public async Task Should_Execute_Void_With_State_Async()
        {
            var state = new State() { Value = 1 };
            var r = await Try.With(state).ExecuteAsync(async ctx => { ctx.Value = await IncreaseAsync(ctx.Value); });

            r.Should().BeTryResult(Void.Value);
            state.Value.Should().Be(2);
        }

        [Fact]
        public async Task Should_Execute_With_State_Async()
        {
            var r = await Try.With(new State { Value = 1 }).ExecuteAsync(ctx => IncreaseAsync(ctx.Value));

            Assert.Equal(2, r.Result); 
            r.Should().BeTryResult(2);
        }
    }
}
