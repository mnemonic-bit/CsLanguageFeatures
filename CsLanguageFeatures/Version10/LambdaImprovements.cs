using FluentAssertions;

namespace CsLanguageFeatures.Version10
{
    public class LambdaImprovements
    {

        [Fact]
        public void Test1()
        {
            // In this case we cannot infer the return type automatically,
            // because Cat and Dog are not assignable to one another.
            var lambda1 = Animal (bool b) => b ? new Dog() : new Cat();

            // In this case we can infer the type because Dog can be
            // assigned to Aninal directly.
            var lambda2 = (bool b) => b ? new Dog() : new Animal();
        }


        private class Animal { }
        private class Dog : Animal { }
        private class Cat : Animal { }


    }
}
