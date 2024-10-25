using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CsLanguageFeatures.Version12
{
    /// <summary>
    /// In the tests in this class we define a lambda function
    /// which has a default parameter. What we want to demonstrate
    /// by those examples is that the default parameter will
    /// behave in the same way as they would with "normal" methods.
    /// </summary>
    public class DefaultLambdaParameters
    {

        [Fact]
        public void DefaultParameter_WillBeSet_WhenOmitted()
        {
            // Arrange
            var greaterThan = (int a, int b = 0) => a > b;

            // Act
            var result = greaterThan(1);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void DefaultParameter_ShouldBeOverwritten_WhenSet()
        {
            // Arrange
            var greaterThan = (int a, int b = 0) => a > b;

            // Act
            var result = greaterThan(5, 3);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void DefaultParameter_ShouldBeNull_WhenOmittedWithNullableTypeWithDefaultValueOfNull()
        {
            // Arrange
            var greaterThan = (int a, int? b = null) => b != null && a > b;

            // Act
            var result = greaterThan(1);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void DefaultParameter_ShouldBeNull_WhenOmittedWithNullableType()
        {
            // Arrange
            var greaterThan = (int a, int? b = 0) => b != null && a > b;

            // Act
            var result = greaterThan(1);

            // Assert
            result.Should().BeTrue();
        }

    }
}
