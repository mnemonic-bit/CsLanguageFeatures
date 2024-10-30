using FluentAssertions;

namespace CsLanguageFeatures.Playground
{
    public class LambdaExpressions
    {

        [Fact]
        public void Test1()
        {
            // Arrange
            var position = 0;

            int[] arr = [11, 12, 13, 14, 15];
            var GetNextElement = (int[] p) => { var res = p[position]; position++; return res; };

            // Act
            var result = GetNextElement(arr);

            // Assert
            position.Should().Be(1);
            result.Should().Be(11);
        }

        /// <summary>
        /// This test defines a lambda-expression which accesses a variable
        /// which is declared in the test-method instead of the lambda method
        /// body. Still this variable will be changed because it is captured
        /// in the context which will be passed along with the lambda method
        /// when it is passed to different methods.
        /// </summary>
        [Fact]
        public void Test2()
        {
            // Arrange
            var position = 0;

            int[] arr = [11, 12, 13, 14, 15];
            var GetNextElement = (int[] p) => { var res = p[position]; position++; return res; };

            // Act
            CallLambda(GetNextElement, arr);

            // Assert
            position.Should().Be(1);
        }


        private static void CallLambda(Func<int[], int> lambda, int[] arr)
        {
            lambda(arr);
        }

    }
}
