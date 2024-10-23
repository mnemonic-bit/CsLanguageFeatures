using FluentAssertions;

namespace CsLanguageFeatures.Version12
{
    public class PrimaryConstructor
    {

        [Fact]
        public void PrimaryConstructor_ShouldSetAllFields_WhenConstructorIsUsed()
        {
            // Arrange
            Person person = new Person("Joe", "User", "juser");

            // Act
            var result = person.ToString();

            // Assert
            result.Should().Be("Joe User (juser)");
        }

        [Fact]
        public void PrimaryConstructor_ShouldSetFirstName_WhenFirstNameIsChanged1()
        {
            // Arrange
            Person person = new Person("Jane", "User", "juser");

            // Act
            person.ChangeFirstName("Joe");
            var result = person.ToString();

            // Assert
            result.Should().Be("Joe User (juser)");
        }

        [Fact]
        public void PrimaryConstructor_ShouldSetFirstName_WhenFirstNameIsChangedInSubclass()
        {
            // Arrange
            Employee person = new Employee("Jane", "User", "juser");

            // Act
            person.ChangeFirstName("Joe");
            var result = person.ToString();

            // Assert
            result.Should().Be("Joe User (juser)");
        }


        /// <summary>
        /// This class demonstrates how the primary constructor fields
        /// can be used when calling the base constructor.
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="LoginName"></param>
        private class Employee(string FirstName, string LastName, string LoginName)
            : Person(FirstName, LastName, LoginName)
        {
        }

        /// <summary>
        /// A primary constructor creates and initializes private fields
        /// which can be used inside of the class implementation.
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="LoginName"></param>
        private class Person(string FirstName, string LastName, string LoginName)
        {

            public void ChangeFirstName(string firstName)
            {
                FirstName = firstName;
            }

            public override string ToString()
            {
                return $"{FirstName} {LastName} ({LoginName})";
            }

        }

        /// <summary>
        /// The primary constructor will set the private fields before
        /// any properties are computed and assigned.
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        private class Triangle(double sideA, double sideB, double sideC)
        {

            public double Circumference { get; } = sideA + sideB + sideC;
            public double Area { get; } = CalculateArea(sideA, sideB, sideC);
            public double SemiPerimeter { get; } = CalculateSemiPerimeter(sideA, sideB, sideC);

            public void Rotate(double angle)
            {
                sideB = angle;
            }

            private static double CalculateArea(double a, double b, double c)
            {
                double s = CalculateSemiPerimeter(a, b, c);
                return Math.Sqrt(s*(s - a)*(s - b)*(s - c));
            }

            private static double CalculateSemiPerimeter(double a, double b, double c)
            {
                return (a + b + c) / 2;
            }

        }

        /// <summary>
        /// The private fields that are created by the primary-constructor are
        /// all readonly because this struct is marked with the readonly-keyword.
        /// In this case we cannot make changes to the values of the private fields.
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        private readonly struct ReadonlyTriangle(double sideA, double sideB, double sideC)
        {

            public double Circumference { get; } = sideA + sideB + sideC;

            public void Rotate(double angle)
            {
                // NOT WORKING BECAUSE THIS STRUCT IS READONLY
                /* sideB = angle; */
            }

        }

        // This example of another Triangle cannot be compiled because
        // we cannot access fields nor properties in initializers because
        // this would make assumptions on the order of execution on those
        // fields or properties.
        /*
        private class Triangle2
        {

            public Triangle2(double sideA, double sideB, double sideC)
            {
                _sideA = sideA;
                _sideB = sideB;
                _sideC = sideC;
            }

            public double Circumference { get; } = _sideA + _sideB + _sideC;
            public double Area { get; } = _sideA;


            private double _sideA;
            private double _sideB;
            private double _sideC;


        }
        */

    }
}
