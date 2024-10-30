using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLanguageFeatures.Version11
{
    /// <summary>
    /// TODO: write some example code.
    ///   * https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11#improved-method-group-conversion-to-delegate
    /// </summary>
    public class MethodGroupConversions
    {

        [Fact]
        public void Test1()
        {
            // Arrange
            Func<int> d = Get42;
            // The compiler now may use the same delegate code as it
            // has generated for variable 'd' from the line above.
            var e = Get42;

            // Act
            var result = d();

            // Assert
            result.Should().Be(42);
        }


        private static int Get42()
        {
            return 42;
        }


    }
}
