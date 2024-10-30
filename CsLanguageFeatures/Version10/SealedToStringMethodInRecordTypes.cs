using FluentAssertions;

namespace CsLanguageFeatures.Version10
{
    public class SealedToStringMethodInRecordTypes
    {

        [Fact]
        public void Test1()
        {
            var amount = new Money(1m);

            amount.ToString().Should().Be("1 (USD)");
        }

        [Fact]
        public void Test2()
        {
            var amount = new MoreMoney(1m, "USD", "This is my pocket money.");

            amount.ToString().Should().Be("1 (USD)");
        }


        private record Money
        {

            public Money(decimal amount, string currencyCode = "USD")
            {
                Amount = amount;
                CurrencyCode = currencyCode;
            }

            public decimal Amount { get; init; }
            public string CurrencyCode { get; init; }

            public sealed override string ToString()
            {
                return $"{Amount} ({CurrencyCode})";
            }

        }

        private record MoreMoney : Money
        {

            public MoreMoney(decimal amount, string currencyCode = "USD", string? comment = null)
                : base(amount, currencyCode)
            {
                Comment = comment;
            }

            public string? Comment { get; init; }

            // THIS DOES NOT COMPILE, BECAUSE ToString() IS SEALED.
            /*
            public override string ToString()
            {
                return string.Empty;
            }
            */

        }

    }
}
