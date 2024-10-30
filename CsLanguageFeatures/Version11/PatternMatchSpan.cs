using FluentAssertions;

namespace CsLanguageFeatures.Version11;

public class PatternMatchSpan
{
    
    [Fact]
    public void PatternMatchSpan_ShouldMatchPattern_WhenTypeIsSpan()
    {
        // Arrange
        ReadOnlySpan<char> text = "This is an ReadOnlySpan<char>";
        
        // Act
        
        // Prior 11 Error: Possibly incorrect string comparison: spans are only equal when pointing to the same memory location. 
        bool isPatternMatched = text is "This is an ReadOnlySpan<char>";
        
        // Assert
        isPatternMatched.Should().BeTrue();
    }

    [Fact]
    public void Test1()
    {
        // Arrange
        ReadOnlySpan<char> text = "This is an ReadOnlySpan<char>";

        // Act
        var isPatternMatched = text is ['T', 'h', 'i', 's', ..];

        // Assert
        isPatternMatched.Should().BeTrue();
    }

    [Fact]
    public void Test2()
    {
        // Arrange
        ReadOnlySpan<char> text = "This is an ReadOnlySpan<char>";

        // Act
        var patternMatchKind = text switch
        {
            "This" => 1,
            // This is dependent on the order in which this pattern is written
            // in source-code, because the pattern overlaps with the next pattern as well.
            ['T', 'h', 'i', 's', ..] => 2,
            "This is an ReadOnlySpan<char>" => 3,
            _ => 0
        };

        // Assert
        patternMatchKind.Should().Be(2);
    }

    [Fact]
    public void Test3()
    {
        // Arrange
        ReadOnlySpan<char> text = "This is an ReadOnlySpan<char>";

        // Act
        var patternMatchKind = text switch
        {
            "This" => 1,
            // This pattern is found first, hence the value we return
            // will be 3 for our test-input.
            "This is an ReadOnlySpan<char>" => 3,
            ['T', ..] => 2,
            _ => 0
        };

        // Assert
        patternMatchKind.Should().Be(3);
    }

}