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
        public void RefReadonlyParameter_ShoundNotChange_WhenPassedToMethod()
        {
            bool ValueCanNotBeChanged(ref readonly int value)
            {
                // THIS WILL NOT COMPILE, BECAUSE value IS A REF READONLY PARAMETER
                /* value = 111; */
                return value == 0;
            }

            // Arrange
            const int NOT_CHANGED = 42;
            int value = NOT_CHANGED;

            // Act
            var result = ValueCanNotBeChanged(ref value);

            // Assert
            value.Should().Be(NOT_CHANGED);
        }

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

        ////////////////////////////////////////////////////////////////////////////////
        // This tests are just for demonstration purposes to show that an in-parameter
        // can have a full-blown expression instead of being just a single parameter.
        ////////////////////////////////////////////////////////////////////////////////

        [Fact]
        public void Test1()
        {
            void Method(ref int value)
            {
                value = 123;
            }

            int value = 42;

            Method(ref value);
            value.Should().Be(123);
        }

        [Fact]
        public void Test2()
        {
            void Method(out int value)
            {
                value = 123;
            }

            int value = 12;
            Method(out value);
            value.Should().Be(123);
        }

        [Fact]
        public void Test3()
        {
            void Method(in int value)
            {
                /*value = 12;*/
            }

            int value = 12;
            Method(value + 1);
        }


        private struct STRCT
        {
            public int X;
            public int Y;
            public int Z;
        }


        [Fact]
        public void Test4()
        {
            void Method(ref STRCT value)
            {
                value = new STRCT();
            }

            STRCT strct = new STRCT();
            strct.X = 12;
            Method(ref strct);

            strct.X.Should().Be(12);
        }

    }
}
