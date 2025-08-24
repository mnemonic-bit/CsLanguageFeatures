using FluentAssertions;
using System.Runtime.CompilerServices;

namespace CsLanguageFeatures.Version12;


/// <summary>
/// Inline Arrays are a new feature in C# 12. They allow you to define an array
/// It is mainly used for performance reasons by Microsoft internally, as it allows the compiler to optimize
/// You as a developer won't use that normally not directly.
/// </summary>
public class InlineArray
{

    [Fact]
    public void InlineArray_ShouldDefineAnArray_WhenNewInstanceIsCreated()
    {
        // Arrange
        // doesn't work with new Collection -Expression or Initializer  ==> convertionError
        // MyInlineIntArray[] myInlineArray = [ 1,2,3,4,5,6,7,8,9,10 ];
        // var MyInlineIntArray = new MyInlineIntArray[10] { 1,2,3,4,5,6,7,8,9,10 };

        var myInlineArray = new MyInlineIntArray();
        for (int i = 0; i < 10; i++)
        {
            myInlineArray[i] = i;
        }

        // Act
        int result = 0;
        foreach (int i in myInlineArray)
        {
            result += i;
        }

        // Assert
        result.Should().Be(45);
    }

    [Fact]
    public void Test()
    {
        (string result, bool b) = GetValue<string>("");
        if (b)
        {
            throw new Exception();
        }

        result.Should().BeNull();
    }

    public (T result, bool error) GetValue<T>(string key)
    {
        return (default, true);
    }

    [Fact]
    public void Test2()
    {
        var sdlkfjs = TryGetValue<string>("", out string value);
        if (!TryGetValue<string>("", out var result))
        {
            throw new Exception();
        }

        result.Should().BeNull();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns>Returns true is a value was found.</returns>
    public bool TryGetValue<T>(string key, out T value)
    {
        value = default;
        return true;
    }

    [InlineArray(10)]
    private struct MyInlineIntArray
    {
        private int _element;
    }

}
