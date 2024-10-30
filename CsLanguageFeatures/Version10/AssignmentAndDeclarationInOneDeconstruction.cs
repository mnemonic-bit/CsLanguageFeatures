using FluentAssertions;

namespace CsLanguageFeatures.Version10
{
    public class AssignmentAndDeclarationInOneDeconstruction
    {

        [Fact]
        public void Test1()
        {
            int x = 12;
            // We can now mix declaration and assignment at the same time.
            (x, int y) = GetPoint();

            x.Should().Be(3);
        }


        private (int x, int y) GetPoint()
        {
            return (3, 99);
        }


    }
}
