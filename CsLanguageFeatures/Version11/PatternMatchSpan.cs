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


    
    
}