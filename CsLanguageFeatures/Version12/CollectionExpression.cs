using FluentAssertions;

namespace CsLanguageFeatures.Version12;


/// <summary>
/// Collection expressions are a new way to initialize collections in C# 12.
/// It is a consisten way to initialize collections, regardless of the type of collection.
/// </summary>
public class CollectionExpression
{

    [Fact]
    public void CollectionExpression_ShouldBeIdentical_WithOldAndNewListInitalization()
    {
        // Arrange
        var classicCollectionInitializer = new List<string> { "A", "B", "C" };
        List<string> CollectionExpression = ["A", "B", "C"]; // This is the new way

        // Act

        // Assert
        CollectionExpression.Should().BeEquivalentTo(classicCollectionInitializer);
    }

    [Fact]
    public void CollectionExpression_ShouldBeIdentical_WithOldAndNewArrayInitalization()
    {
        // Arrange
        var classicArrayVariant1 = new[] { "a", "b", "c", "d" };
        var classicArrayVariant2 = new string[4] { "a", "b", "c", "d" };
        string[] classicArrayVariant3 = { "a", "b", "c", "d" };

        string[] collectionExpression = ["a", "b", "c", "d"]; // This is the new way

        // Act

        // Assert
        collectionExpression.Should().BeEquivalentTo(classicArrayVariant1);
        collectionExpression.Should().BeEquivalentTo(classicArrayVariant2);
        collectionExpression.Should().BeEquivalentTo(classicArrayVariant3);
    }

    [Fact]
    public void CollectionExpression_ShouldBe() 
    {
        // Arrange
        ReadOnlySpan<int> classicSpan = stackalloc[] { 1, 2, 3 };
        ReadOnlySpan<int> collectionExpressionSpan = [1, 2, 3]; // This is the new way
        // Act

        // Assert
        collectionExpressionSpan.ToArray().Should().BeEquivalentTo(classicSpan.ToArray());
    }


    [Fact]
    public void CollectionExpression_ShouldSpread_WhenExecuted()
    {
        // Arrange
        List<string> start = new() {  "b", "c" ,"d"}; // The source list can be any IEnumerable collection
        IEnumerable<string> end = ["f", "g"]; // regardless of how it was created
        
        // Act
        string[] all = ["a", ..start, "e", ..end, "h"];
        
        // Assert
        all.Should().BeEquivalentTo(new[] { "a", "b", "c", "d", "e", "f", "g", "h" });
    }

}