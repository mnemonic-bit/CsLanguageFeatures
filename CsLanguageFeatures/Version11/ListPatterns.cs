using FluentAssertions;

namespace CsLanguageFeatures.Version11;

public class ListPatterns
{
    // List patterns extend pattern matching to match sequences of elements in a list or an array.

    [Fact]
    public void ListPatterns_ShouldPass_WhenListHasMoreThan3ElementsStartsWith1AndEndsWith5()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4, 5 };
        string result = string.Empty;
        
        // Act
        if (list is { Count: > 3 } and [1, .. , 5] )
        { 
            result = "List has more than 3 elements, starts with 1, and ends with 5.";
        }
        
        // Assert
        result.Should().Be("List has more than 3 elements, starts with 1, and ends with 5.");
    }
    
    [Fact]
    public void ListPattern_ShouldMatchPatternsCorrectly()
    {
        // Arrange
        int[] numbers = { 1, 2, 3 };

        // Assert
  
        var variant1 = numbers is [1, 2, 4]; 
        var variant2 = numbers is [1, 2, 3];
        var variant3 = numbers is [0 or 1, <= 2, >= 3];
        var variant4 = numbers is [1, _, 3]; 
        variant1.Should().BeFalse();
        variant2.Should().BeTrue();
        variant3.Should().BeTrue();
        variant4.Should().BeTrue();
        
        if (numbers is [var variant5, .. var rest])
        {
            variant5.Should().Be(1);
            rest.Should().BeEquivalentTo(new[] { 2, 3 });
        }
    }
    
    [Theory]
    [InlineData(new string[] { }, "no Name found")]
    [InlineData(new string[] { "John Doe" }, "My full name is: John Doe")]
    [InlineData(new string[] { "Ernest", "Hemingway" }, "My firstname and lastname is: Ernest Hemingway")]
    public void ListPattern_ShouldMatchPatternsCorrectly_WithDifferentInputs(string[] nameSplitted, string expected)
    {
        var text = nameSplitted switch
        {
            [] => "no Name found",
            [var fullName] => $"My full name is: {fullName}",
            [var firstName, var lastName] => $"My firstname and lastname is: {firstName} {lastName}"
        };

        text.Should().Be(expected);
    }

}