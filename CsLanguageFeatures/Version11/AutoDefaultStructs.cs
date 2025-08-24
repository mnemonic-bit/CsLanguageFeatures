using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLanguageFeatures.Version11
{
    /// <summary>
    /// Now that we have auto-default structs, we do not need to
    /// init all properties of a struct in the constructor. Instead,
    /// all other fields which were not initialized in a constructor,
    /// will be set to their default value automatically. Thats why
    /// they are called auto-default structs after all.
    /// 
    /// The first test demonstrates that initializing a struct with
    /// a constructor sets its properties to values the constructor
    /// sets. The constructor even overwrites values which were set
    /// as property-initializer.
    /// 
    /// The second test shows that all properties of a struct will be
    /// set to their default values, if we use the default-keyword
    /// to obtain an instance of that struct. In this case the
    /// constructor is not called at all, and even the property-
    /// initializer will not be called.
    /// </summary>
    public class AutoDefaultStructs
    {

        [Fact]
        public void Test1()
        {
            // Arrange
            // Act
            var customStruct = new CustomStruct();

            // Assert
            customStruct.Value.Should().Be(42);
            customStruct.Text.Should().Be("TextSetInTheConstructor");
            customStruct.UninitializedValue.Should().Be(0);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            // Act
            var customStruct = default(CustomStruct);

            // Assert
            customStruct.Value.Should().Be(0);
            customStruct.Text.Should().BeNull();
            customStruct.UninitializedValue.Should().Be(0);
        }


        private struct CustomStruct
        {

            public CustomStruct()
            {
                Value = 42;
                Text = "TextSetInTheConstructor";
            }

            public int Value { get; set; }
            public string Text { get; set; } = "UninitialText";
            // This property is not initialized at all, not in the
            // constructor, nor directly where its defined. It will
            // be set to 0 when an instance is initialized.
            // Most notably there is no compiler-warning or error.
            public int UninitializedValue { get; set; }

        }

    }
}
