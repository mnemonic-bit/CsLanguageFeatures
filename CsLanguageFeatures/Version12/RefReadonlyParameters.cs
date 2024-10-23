using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLanguageFeatures.Version12
{
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
