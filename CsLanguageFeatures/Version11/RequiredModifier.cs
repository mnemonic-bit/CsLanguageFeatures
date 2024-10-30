using System.Security.Principal;
using FluentAssertions;

namespace CsLanguageFeatures;

public class RequiredModifier
{
    // The required modifier indicates that the field or property it's
    // applied to must be initialized by an object initializer.
    // Any expression that initializes a new instance of the type must initialize all required members.


    [Fact]
    public void Test1()
    {
        // Arrange
        PersonWithRequirementModifier person = new PersonWithRequirementModifier
        {
            FirstName = "John",
            LastName = "Doe",
            // Age' must be set in the object initializer
            Age = 30
        };
        
        // Act
        // person.Age = 30; Error: Property or indexer 'PersonWithoutRequired.Age' cannot be assigned, it is read only

        // Assert
        person.Age.Should().Be(0);
    }
    
    public class PersonWithRequirementModifier
    {
        // The default constructor requires that FirstName and LastName be set at construction time
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required int Age { get; init; }
    }
    
    
    [Fact]
    public void Test2()
    {
        // Arrange
        PersonWithoutRequiredModifier person = new PersonWithoutRequiredModifier
        {
            FirstName = "John",
            LastName = "Doe",
            //Age = forget to set the Age;
        };
        
        // Act
        // person.Age = 30; Error: Property or indexer 'PersonWithoutRequired.Age' cannot be assigned, it is read only

        // Assert
        person.Age.Should().Be(30);
    }
    
    public class PersonWithoutRequiredModifier
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }
    }

    [Fact]
    public void Test3()
    {
        // This won't work, because required properties
        // must be initialized as property initializer.
        /*var person = new PersonWithRequiredModifierAndConstructor("Joe", "User")
        {
            Age = 30
        };*/
    }

    public class PersonWithRequiredModifierAndConstructor
    {

        public PersonWithRequiredModifierAndConstructor(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required int Age { get; init; }

    }

}