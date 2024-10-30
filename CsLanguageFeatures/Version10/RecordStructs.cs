using FluentAssertions;

namespace CsLanguageFeatures.Version10
{
    public class RecordStructs
    {

        [Fact]
        public void Test1()
        {
            // Arrage
            // Act
            var amount = new Money3(); // This works because we have auto-default structs available since C#11

            // Assert
            amount.Should().NotBeNull();
            amount.Amount.Should().Be(0m);
            amount.CurrencyCode.Should().BeNull();
        }

        [Fact]
        public void Test2()
        {
            // Arrage
            // Act
            var amount = new Money3(2.54m, "USD");
            amount.CurrencyCode = string.Empty;

            // Assert
            amount.Should().NotBeNull();
        }

        [Fact]
        public void Test3()
        {
            var money = new Money4(100m, "USD");
            var money2 = money with { Amount = 3 };
        }


        // C#9, may be null, is immutable, because its compiled into a class.
        private record Money1(decimal Amount, string CurrencyCode);

        // C#10, this is the same as just record, and should clarify that
        // its the same as using just record, because that is compiled as
        // a class.
        private record class Money2
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
        }

        // C#10, may not be null, is mutable
        private record struct Money3(decimal Amount, string CurrencyCode);

        // C#10, may not be null, is mutable in theory, hence readonly keyword. 
        private readonly record struct Money4(decimal Amount, string CurrencyCode);


    }
}
