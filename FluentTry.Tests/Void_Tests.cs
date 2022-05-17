using Xunit;

namespace FluentTry.Tests
{
    public class Void_Tests
    {
        [Fact]
        public void Should_Equal()
        {
            Assert.Equal(Void.Value, Void.Value);
            Assert.Equal(new Void(), Void.Value);
            Assert.Equal(default, new Void());
            Assert.True(default == Void.Value);
            Assert.False(default != Void.Value);
            Assert.True(Void.Value.Equals(default));
        }

        [Fact]
        public void Should_Have_Zero_Hashcode()
        {
            Assert.Equal(0, new Void().GetHashCode());
            Assert.Equal(0, Void.Value.GetHashCode());
        }
    }
}