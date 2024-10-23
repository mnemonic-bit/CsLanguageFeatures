using FluentAssertions;

namespace CsLanguageFeatures.Version12
{
    /// <summary>
    /// This tests show that we can define ref parameters which cannot be changed
    /// from inside the method itself. As opposed to an in-parameter type, which
    /// can hold any expression instead of a single parameter name, the ref-readonly
    /// signals to the caller that only a single variable is allowed here, and that
    /// its value will not be changed inside the called method.
    /// </summary>
    public class RefReadonlyParameters
    {

        [Fact]
        public void RefReadonlyParameter_ShouldNotChange_AfterItWasPassedToMethod()
        {
            // Arrange
            const int TWELVE = 12;
            int value = TWELVE;

            // Act
            var result = IsZero(ref value);

            // Assert
            result.Should().BeFalse();
            value.Should().Be(TWELVE);
        }

        /// <summary>
        /// This test is just for demonstration purposes to show that an in-parameter
        /// can have a full-blown expression instead of being just a single parameter.
        /// </summary>
        [Fact]
        public void InParameter_ShouldBehaveLikeRefReadonly_WhenPassedAnExpression()
        {
            bool InParameter(in int value)
            {
                return value == 0;
            }

            // Arrange
            const int TWELVE = 12;
            int value = TWELVE;

            // Act
            var result = InParameter(value + 1);

            // Assert
            value.Should().Be(TWELVE);
        }


        /// <summary>
        /// This method does not change the referenced value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsZero(ref readonly int value)
        {
            return value == 0;
        }

        private bool IsZeroWithCompileErrors(ref readonly int value)
        {
            // THIS WILL NOT COMPILE, BECAUSE value IS A REF READONLY PARAMETER
            /* value = 0; */
            return value == 0;
        }

    }
}
