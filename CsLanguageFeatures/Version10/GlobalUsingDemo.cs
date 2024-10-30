using FluentAssertions;

namespace CsLanguageFeatures.Version10
{
    public class GlobalUsingDemo
    {

        [Fact]
        public void Test1()
        {
            DataLength length = 12;
            DataBlock b = new byte[length];

            b.Should().NotBeNull();
            b.Length.Should().Be(length);
        }

    }
}
