using FluentAssertions;

namespace CsLanguageFeatures.Version11
{

    public class FileScopedTypes
    {

        [Fact]
        public void Test()
        {
            // Arrange
            // Act
            var fileScopedType = new ThisClassCanOnlyBeSeenFromCodeWithinThisFile();

            // Assert
            fileScopedType.Should().NotBeNull();
        }

    }

    /// <summary>
    /// This is a file-scoped type, i.e. that this type can only be used in
    /// code which lives inside this file.
    /// </summary>
    file class ThisClassCanOnlyBeSeenFromCodeWithinThisFile
    {
        public int Value { get; set; }
    }

}
